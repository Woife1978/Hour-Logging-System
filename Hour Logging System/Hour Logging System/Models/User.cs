using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Hour_Logging_System.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public bool IsAdmin { get; set; }
        public List<Hours> Hours { get; set; }
    }

    //Each user will have a set of hours for each day along with a value for 
    public class Hours
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Paid { get; set; }
        public string Notes { get; set; }
    }
}
