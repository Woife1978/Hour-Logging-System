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
        public bool Insert(Employee employee)
        {
            var database = Client.GetDatabase("EmployeeAttendance");
            var collection = database.GetCollection<Employee>("Employees");

            var list = collection.Find(x => x.FirstName == employee.FirstName && x.LastName == employee.LastName).ToList();

            if (list == null)
            {
                collection.InsertOne(employee);
                return true;
            }
            else
            {
                return false;
            }

            

        }

        //public T Get<T>()
        //{
            

        //}

        public void Update(Employee item)
        {

        }

        public void Delete()
        {

        }
    }
}
