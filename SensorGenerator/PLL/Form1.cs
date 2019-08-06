using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SensorGenerator.DAL;
using SensorGenerator.BLL;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using Troschuetz.Random;
using Randomizer;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace SensorGenerator
{
    public partial class Form1 : Form
    {
        SensorDataBLL sensorData = new SensorDataBLL();
        List<KafkaModel> patientList = new List<KafkaModel>();
        List<int> patientIndexSelectedRemote = new List<int>();
        List<int> patientIndexSelectedHospitalization = new List<int>();
        private int countedPatients = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           if (!radioMinute.Checked && !radioSecond.Checked)
            {
                MessageBox.Show("You must select the unit of time to generate data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (countedPatients  < 1)
            {
                MessageBox.Show("You must select at least one patient to generate data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sensorTimer.Enabled = true;
            if (sensorTimer.Enabled)
            {
                if(radioSecond.Checked)
                {
                    sensorTimer.Interval = (int)TimeSpan.FromSeconds((double)numericInterval.Value).TotalMilliseconds;
                } else
                {
                    sensorTimer.Interval = (int) TimeSpan.FromMinutes((double)numericInterval.Value).TotalMilliseconds;
                }
                sensorTimer.Start();
            }
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Expand();
            foreach (SensorModelRemoteControl  sensor in sensorData.remoteControlData())
            {
                treeView1.Nodes[0].Nodes[0].Nodes.Add(sensor.PatientName + " " + sensor.PatientSurname);
                mapMarker(Convert.ToDouble(sensor.PatientLat), Convert.ToDouble(sensor.PatientLng), sensor.PatientName + " " + sensor.PatientSurname);
            }

            foreach (SensorModelHospitalization sensor in sensorData.hospitalizationData())
            {
           
                treeView1.Nodes[0].Nodes[1].Nodes.Add(sensor.PatientName + " " + sensor.PatientSurname);
                mapMarker(Convert.ToDouble(sensor.PatientLat), Convert.ToDouble(sensor.PatientLng), sensor.PatientName + " " + sensor.PatientSurname);
            }

            mapInitializer(42.628293, 20.889290);

        }

        private void sensorTimer_Tick(object sender, EventArgs e)
        {

            Random number = new Random();
            int guessing = number.Next(0, 1000);
            RandomDoubleGenerator random = new RandomDoubleGenerator();           
            foreach (var patientIndex in patientIndexSelectedRemote)
            {
                KafkaModel kafkaModel = new KafkaModel();
                kafkaModel.SensorId = sensorData.remoteControlData()[patientIndex].SensorId;
                kafkaModel.PatientId = sensorData.remoteControlData()[patientIndex].PatientId;
                kafkaModel.DoctorId = sensorData.remoteControlData()[patientIndex].DoctorId;
                kafkaModel.SensorType = sensorData.remoteControlData()[patientIndex].SensorType;
                kafkaModel.ParameterUnitMeasured = sensorData.remoteControlData()[patientIndex].ParameterUnitMeasured;
                kafkaModel.PatientDiagnosis = sensorData.remoteControlData()[patientIndex].PatientDiagnosis;
                var minValue = sensorData.remoteControlData()[patientIndex].ParameterMinValue;
                var maxValue = sensorData.remoteControlData()[patientIndex].ParameterMaxValue;
                var normalMax = sensorData.remoteControlData()[patientIndex].ParameterNormalMaxValue;
                var normalMin = sensorData.remoteControlData()[patientIndex].ParameterNormalMinValue;
                if (guessing == 274 || guessing == 554 || guessing == 799)
                {
                    if (sensorData.remoteControlData()[patientIndex].ParameterName == "blood pressure")
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(minValue, normalMax - 15.00), 4);
                        kafkaModel.SensorValues[1] = Math.Round(random.GenerateValue(normalMax - 5.00, maxValue), 4);
                    }
                    else
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(minValue, maxValue), 4);
                        kafkaModel.SensorValues[1] = 0;
                    }

                }
                else
                {
                    if (sensorData.remoteControlData()[patientIndex].ParameterName == "blood pressure")
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(normalMin, normalMin + 10.00), 4);
                        kafkaModel.SensorValues[1] = Math.Round(random.GenerateValue(normalMax - 5.00, maxValue), 4);
                    }
                    else
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(normalMin, normalMax), 4);
                        kafkaModel.SensorValues[1] = 0;
                    }

                }
                patientList.Add(kafkaModel);
            }

            foreach (var patientIndex in patientIndexSelectedHospitalization)
            {
                KafkaModel kafkaModel = new KafkaModel();
                kafkaModel.SensorId = sensorData.hospitalizationData()[patientIndex].SensorId;
                kafkaModel.PatientId = sensorData.hospitalizationData()[patientIndex].PatientId;
                kafkaModel.DoctorId = sensorData.hospitalizationData()[patientIndex].DoctorId;
                kafkaModel.SensorType = sensorData.hospitalizationData()[patientIndex].SensorType;
                kafkaModel.ParameterUnitMeasured = sensorData.hospitalizationData()[patientIndex].ParameterUnitMeasured;
                kafkaModel.PatientDiagnosis = sensorData.hospitalizationData()[patientIndex].PatientDiagnosis;
                var minValue = sensorData.hospitalizationData()[patientIndex].ParameterMinValue;
                var maxValue = sensorData.hospitalizationData()[patientIndex].ParameterMaxValue;
                var normalMax = sensorData.hospitalizationData()[patientIndex].ParameterNormalMaxValue;
                var normalMin = sensorData.hospitalizationData()[patientIndex].ParameterNormalMinValue; if (guessing == 274 || guessing == 554 || guessing == 799)
                {
                    if (sensorData.hospitalizationData()[patientIndex].ParameterName == "blood pressure")
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(minValue, normalMax - 15.00), 4);
                        kafkaModel.SensorValues[1] = Math.Round(random.GenerateValue(normalMax - 5.00, maxValue), 4);
                    }
                    else
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(minValue, maxValue), 4);
                        kafkaModel.SensorValues[1] = 0;
                    }

                }
                else
                {
                    if (sensorData.hospitalizationData()[patientIndex].ParameterName == "blood pressure")
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(normalMin, normalMin + 10.00), 4);
                        kafkaModel.SensorValues[1] = Math.Round(random.GenerateValue(normalMax - 5.00, maxValue), 4);
                    }
                    else
                    {
                        kafkaModel.SensorValues[0] = Math.Round(random.GenerateValue(normalMin, normalMax), 4);
                        kafkaModel.SensorValues[1] = 0;
                    }

                }
                patientList.Add(kafkaModel);
            }


            var jsonData = JsonConvert.SerializeObject(patientList, Formatting.Indented);

            using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = "localhost:9092" }).Build())
            {
                try
                {
                    // Warning: The API for this functionality is subject to change.
                    var meta = adminClient.GetMetadata(TimeSpan.FromSeconds(1));
                    lblProperties.Text = "Kafka Broker and Topic properties:";
                    label1.Text = "Broker Id, Broker Name: ";
                    label2.Text = "Topic name: ";
                    label3.Text = "Partition: ";
                    label4.Text = "Replicas: ";
                    
                    
                    meta.Brokers.ForEach(broker =>
                    lblBrokerIdBrokerName.Text = (broker.BrokerId + ", " + broker.Host +":"+broker.Port).ToString());
                    lblTopic.Text = meta.Topics[2].Topic;
                    meta.Topics[2].Partitions.ForEach(partition =>
                    {
                        lblPartition.Text = partition.PartitionId.ToString();
                        lblReplicas.Text = partition.Replicas.ToString();
                    });
                    lblCountPatients.Text = "Data are sending to Kafka...";
                    var conf = new ProducerConfig { BootstrapServers = "localhost:9092" };
                    Action<DeliveryReport<Null, string>> handler = r =>
                    {
                        if(r.Error.IsError)
                        {
                            lblCountPatients.Text = "An error occurred. Message: " + r.Error.Reason;
                        } else { patientList.Clear(); }
                        Console.WriteLine(!r.Error.IsError
                        ? "Delivered message to" + r.TopicPartitionOffset
                        : "Delivery Error: " + r.Error.Reason);
                    };
   
                   
                    using (var p = new ProducerBuilder<Null, string>(conf).Build())
                    {

                        p.Produce("sensor-generator", new Message<Null, string> { Value = jsonData }, handler);

                        // wait for up to 10 seconds for any inflight messages to be delivered.
                        p.Flush(TimeSpan.FromSeconds(10));
                    }
                    
                }
                catch (KafkaException ex)
                {
                    sensorTimer.Enabled = false;
                    sensorTimer.Stop();
                    MessageBox.Show(ex.Message + ": Could not connect to Kafka Server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void chkSelectUnselect_CheckedChanged(object sender, EventArgs e)
        {
          if(chkSelectUnselect.Checked)
            {
                CheckAllNodes(treeView1.Nodes);
            } else
            {
                UncheckAllNodes(treeView1.Nodes);
            }
        }

        public void mapInitializer(double lat, double lng)
        {
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Position = new PointLatLng(lat, lng);
            gmap.ShowCenter = false;
            gmap.Zoom = 9;
            gmap.MinZoom = 9;
            gmap.MaxZoom = 100;
            gmap.DragButton = MouseButtons.Left;
        }

        public void mapMarker (double lat, double lng, string fullName)
        {
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);
            GMapOverlay markers = new GMapOverlay("marker");
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
            marker.ToolTipText = $"Patient's Full Name: {fullName}";
            var tooltip = new GMapToolTip(marker);
            tooltip.Fill = new SolidBrush(Color.DarkViolet);
            tooltip.Foreground = new SolidBrush(Color.White);
            tooltip.Offset = new Point(20, 10 );
            marker.ToolTip = tooltip;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
              childNode.Checked = e.Node.Checked;
                  
            }

            int countSelectedNodes = 0;
           
            foreach (TreeNode countNodes in treeView1.Nodes[0].Nodes[0].Nodes)
            {
               
                if (countNodes.Checked)
                {
                    if (!patientIndexSelectedRemote.Contains(countNodes.Index))
                    {
                        patientIndexSelectedRemote.Add(countNodes.Index);
                    }
                    countSelectedNodes++;
                }
            }
            foreach (TreeNode countNodes in treeView1.Nodes[0].Nodes[1].Nodes)
            {
                if (countNodes.Checked)
                {
                    if (!patientIndexSelectedHospitalization.Contains(countNodes.Index))
                    {
                        patientIndexSelectedHospitalization.Add(countNodes.Index);
                    }
                    countSelectedNodes++;
                }
            }
            lblCountPatients.Text = countSelectedNodes > 1 ? countSelectedNodes.ToString() + " patients ready for sending to Kafka..." :
                countSelectedNodes.ToString() + " patient ready for sending to Kafka...";
            countedPatients = countSelectedNodes;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }
        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }
    }
}
