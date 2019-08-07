using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGenerator.DAL
{
    public class KafkaModel
    {
        public int PatientId { get; set; }// remove
        public int DoctorId { get; set; } //remove
        public int SensorId { get; set; }
        public string ParameterUnitMeasured { get; set; } // remove
        public string SensorType { get; set; } // remove
        public string PatientDiagnosis { get; set; } // remove
        public double[] SensorValues = new double[2]; 
    }
}
