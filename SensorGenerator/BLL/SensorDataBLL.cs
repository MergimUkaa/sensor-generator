using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SensorGenerator.DAL;
namespace SensorGenerator.BLL
{
    public class SensorDataBLL
    {
        public List<SensorModelHospitalization> hospitalizationData()
        {
            SensorDataDAL sensorData = new SensorDataDAL();
            return sensorData.getSensorDataHospitalization();
        }
        public List<SensorModelRemoteControl> remoteControlData()
        {
            SensorDataDAL sensorData = new SensorDataDAL();
            return sensorData.getSensorDataRemoteControl();
        }
    }
}
