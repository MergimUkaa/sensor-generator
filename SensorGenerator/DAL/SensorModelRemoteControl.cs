using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGenerator.DAL
{
    public class SensorModelRemoteControl
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientLat { get; set; }
        public string PatientLng { get; set; }
        public int VisitId { get; set; }
        public string PatientDiagnosis { get; set; }
        public string DateOfVisit { get; set; }
        public string PlaceOfPatient { get; set; }
        public int DoctorId { get; set; }
        public string MonitoringDoctorName { get; set; }
        public string MonitoringDoctorSurname { get; set; }
        public int SensorId { get; set; }
        public string ParameterName { get; set; }
        public double ParameterMinValue { get; set; }
        public double ParameterMaxValue { get; set; }
        public double ParameterNormalMinValue { get; set; }
        public double ParameterNormalMaxValue { get; set; }
        public string ParameterUnitMeasured { get; set; }
        public string SensorType { get; set; }  
    }
}
