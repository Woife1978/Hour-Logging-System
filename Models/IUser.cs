using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hour_Logging_System.Models
{
    public interface IUser
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
    }
}
