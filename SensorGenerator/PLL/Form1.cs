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
        SensorModelRemoteControl dataSendToKafkaRemoteControl;
        SensorModelHospitalization dataSendToKafkaHospitalization;
        private double maxValue, minValue, normalMax, normalMin;
        private string parameterName;
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

            //Random number = new Random();
            //int guessing = number.Next(0, 1000);
            //RandomDoubleGenerator random = new RandomDoubleGenerator();
            //double sensorValues, sensorValues1;
            //if (guessing == 274 || guessing == 554 || guessing == 799)
            //{
            //    if (parameterName == "blood pressure")
            //    {
            //        sensorValues = Math.Round(random.GenerateValue(minValue, normalMax - 15.00), 4);
            //        sensorValues1 = Math.Round(random.GenerateValue(normalMax - 5.00, maxValue), 4);
            //    }
            //    else
            //    {
            //        sensorValues = Math.Round(random.GenerateValue(minValue, maxValue), 4);
            //        sensorValues1 = 0;
            //    }

            //}
            //else
            //{
            //    if (parameterName == "blood pressure")
            //    {
            //        sensorValues = Math.Round(random.GenerateValue(normalMin, normalMin + 10.00), 4);
            //        sensorValues1 = Math.Round(random.GenerateValue(normalMax - 5.00, maxValue), 4);
            //    }
            //    else
            //    {
            //        sensorValues = Math.Round(random.GenerateValue(normalMin, normalMax), 4);
            //        sensorValues1 = 0;
            //    }

            //}

            //string jsonData = String.Empty;
            //if (true) // hospitalizations
            //{
            //    JObject jo = JObject.FromObject(dataSendToKafkaHospitalization);
            //    if (parameterName == "blood pressure")
            //    {
            //        jo.Add("sensorValue", sensorValues);
            //        jo.Add("sensorValue1", sensorValues1);
            //    }
            //    else
            //    {
            //        jo.Add("sensorValue", sensorValues);
            //    }
            //    jsonData = jo.ToString();
            //}
            //else if (true)
            //{
            //    JObject jo = JObject.FromObject(dataSendToKafkaRemoteControl);
            //    if (parameterName == "blood pressure")
            //    {
            //        jo.Add("sensorValue", sensorValues);
            //        jo.Add("sensorValue1", sensorValues1);
            //    }
            //    else
            //    {
            //        jo.Add("sensorValue", sensorValues);
            //    }
            //    jsonData = jo.ToString();
            //}

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
                        lblReplicas.Text = partition.Replicas[0].ToString();
                    });
                    lblCountPatients.Text = "Data are sending to Kafka...";
                }
                catch (KafkaException ex)
                {
                    sensorTimer.Enabled = false;
                    sensorTimer.Stop();
                    MessageBox.Show(ex.Message + ": Could not connect to Kafka Server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }

            // var conf = new ProducerConfig { BootstrapServers = "localhost:9092" };
            // Action<DeliveryReport<Null, string>> handler = r =>
            //Console.WriteLine(!r.Error.IsError
            // ? "Delivered message to" + r.TopicPartitionOffset
            // : "Delivery Error: " + r.Error.Reason);
            // using (var p = new ProducerBuilder<Null, string>(conf).Build())
            // {

            //     p.Produce("sensor-generator", new Message<Null, string> { Value = "hello" }, handler);

            //     // wait for up to 10 seconds for any inflight messages to be delivered.
            //     p.Flush(TimeSpan.FromSeconds(10));
            // }



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
                    countSelectedNodes++;
                }
            }
            foreach (TreeNode countNodes in treeView1.Nodes[0].Nodes[1].Nodes)
            {
                if (countNodes.Checked)
                {
                    countSelectedNodes++;
                }
            }
            lblCountPatients.Text = countSelectedNodes > 1 ? countSelectedNodes.ToString() + " patients ready for sending to Kafka..." :
                countSelectedNodes.ToString() + " patient ready for sending to Kafka...";
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
