using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SensorGenerator.DAL
{
    public class SensorDataDAL
    {
        public List<SensorModelHospitalization> getSensorDataHospitalization()
        {
             List<SensorModelHospitalization> sensorList = new List<SensorModelHospitalization>();
             Connection conn = new Connection();
            if(ConnectionState.Closed == conn.conn.State)
            {
                conn.conn.Open(); 
            }
        
            using(var command = new MySqlCommand("getSensorsDataHospitalization", conn.conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                   using (MySqlDataReader mdr = command.ExecuteReader())
                    {
                        while (mdr.Read())
                        {
                            SensorModelHospitalization sensorModel = new SensorModelHospitalization();
                            sensorModel.PatientId = mdr.GetInt32(0);
                            sensorModel.PatientName = mdr.GetString(1);
                            sensorModel.PatientSurname = mdr.GetString(2);
                            sensorModel.PatientLat = mdr.GetString(3);
                            sensorModel.PatientLng = mdr.GetString(4);
                            sensorModel.VisitId = mdr.GetInt32(5);
                            sensorModel.PatientDiagnosis = mdr.GetString(6);
                            sensorModel.DateOfVisit = mdr.GetString(7);
                            sensorModel.PlaceOfPatient = mdr.GetString(8);
                            sensorModel.DoctorId = mdr.GetInt32(9);
                            sensorModel.MonitoringDoctorName = mdr.GetString(10);
                            sensorModel.MonitoringDoctorSurname = mdr.GetString(11);
                            sensorModel.HospitalName = mdr.GetString(12);
                            sensorModel.RepartName = mdr.GetString(13);
                            sensorModel.RoomNumber = mdr.GetInt32(14);
                            sensorModel.BedNumber = mdr.GetInt32(15);
                            sensorModel.SensorId = mdr.GetInt32(16);
                            sensorModel.ParameterName = mdr.GetString(17);
                            sensorModel.ParameterMinValue = mdr.GetDouble(18);
                            sensorModel.ParameterMaxValue = mdr.GetDouble(19);
                            sensorModel.ParameterNormalMinValue = mdr.GetDouble(20);
                            sensorModel.ParameterNormalMaxValue = mdr.GetDouble(21);
                            sensorModel.ParameterUnitMeasured = mdr.GetString(22);
                            sensorModel.SensorType = mdr.GetString(23);
                            sensorList.Add(sensorModel);

                        }
                    }
                    return sensorList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }

        public List<SensorModelRemoteControl> getSensorDataRemoteControl()
        {
            List<SensorModelRemoteControl> sensorList = new List<SensorModelRemoteControl>();
            Connection conn = new Connection();
            if (ConnectionState.Closed == conn.conn.State)
            {
                conn.conn.Open();
            }

            using(var command = new MySqlCommand("getSensorDataRemoteControl", conn.conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    using(MySqlDataReader mdr = command.ExecuteReader())
                    {
                        while (mdr.Read())
                        {
                            SensorModelRemoteControl sensorModel = new SensorModelRemoteControl();
                            sensorModel.PatientId = mdr.GetInt32(0);
                            sensorModel.PatientName = mdr.GetString(1);
                            sensorModel.PatientSurname = mdr.GetString(2);
                            sensorModel.PatientLat = mdr.GetString(3);
                            sensorModel.PatientLng = mdr.GetString(4);
                            sensorModel.VisitId = mdr.GetInt32(5);
                            sensorModel.PatientDiagnosis = mdr.GetString(6);
                            sensorModel.DateOfVisit = mdr.GetString(7);
                            sensorModel.PlaceOfPatient = mdr.GetString(8);
                            sensorModel.DoctorId = mdr.GetInt32(9);
                            sensorModel.MonitoringDoctorName = mdr.GetString(10);
                            sensorModel.MonitoringDoctorSurname = mdr.GetString(11);
                            sensorModel.SensorId = mdr.GetInt32(12);
                            sensorModel.ParameterName = mdr.GetString(13);
                            sensorModel.ParameterMinValue = mdr.GetDouble(14);
                            sensorModel.ParameterMaxValue = mdr.GetDouble(15);
                            sensorModel.ParameterNormalMinValue = mdr.GetDouble(16);
                            sensorModel.ParameterNormalMaxValue = mdr.GetDouble(17);
                            sensorModel.ParameterUnitMeasured = mdr.GetString(18);
                            sensorModel.SensorType = mdr.GetString(19);
                            sensorList.Add(sensorModel);

                        }
                    }
                    
                    return sensorList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }
    }
}
