using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Village_MVC.Models
{
    public class Resident
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fatherName { get; set; }
        public string Gender { get; set; }
        public bool bornInVillage { get; set; }
        public int  yearOfBirth { get; set; }


    }
}