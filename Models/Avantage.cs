using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApi.Models{
    public class Avantage{    
        public int AvantageID { get; set; }
        public string? Nom { get; set; }
        public int EmployerID {get; set; }
  
    }
}