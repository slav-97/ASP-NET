using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.Models.StoreModels
{
    public class Features
    {
        public int Id { get; set; }
        public string Appointment { get; set; }
        public string MemoryType { get; set; }
        public int MemoryCapacity { get; set; }
        public double Frequency { get; set; }
        public double Voltage { get; set; }
    }
}