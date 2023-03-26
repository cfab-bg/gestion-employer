using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApi.Models{
    public class Employer{    
        public int EmployerID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Date { get; set; }
        public List<Avantage> Avantages { get; set; }
    }
}