using System.Collections.Generic;
using Hour_Logging_System.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Hour_Logging_System.Mongo
{
    public class MongoHandler
    {
        private static string ConnectionString { get; } = "mongodb://EmployeeAttendance:C5cScKv75yE2Gfie@luke-else.com/EmployeeAttendance?authDatabase=EmployeeAttendance&retryWrites=true&w=majority";

        private MongoClient Client { get; set; } = new MongoClient(ConnectionString);

        //Database Methods
        public void Insert(User item)
        {

        }
        public T Get<T>()
        {
            
        }

        public void Update(User item)
        {

        }

        public void Delete()
        {

        }
    }
}
