using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGenerator.DAL
{
    public class KafkaModel
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int SensorId { get; set; }
        public string ParameterUnitMeasured { get; set; }
        public string SensorType { get; set; }
        public string PatientDiagnosis { get; set; }
        public double[] SensorValues = new double[2]; 
    }
}
