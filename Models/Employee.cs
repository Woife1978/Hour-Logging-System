using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Hour_Logging_System.Models
{
    public class Employee : IUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public List<Hours> Hours { get; set; }
    }

    //Each user will have a set of hours for each day along with a value for its status and any notes they make
    public class Hours
    {
        public DateTime? Start { get; set; } = null;
        public DateTime? End { get; set; } = null;
        public bool Paid { get; set; }
        public string Notes { get; set; }
    }
}
