﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorGenerator.DAL
{
    public class KafkaModel
    {
        public int SensorId { get; set; }
        public string ParameterUnitMeasured { get; set; } // remove
        public double[] SensorValues = new double[2]; 
    }
}
