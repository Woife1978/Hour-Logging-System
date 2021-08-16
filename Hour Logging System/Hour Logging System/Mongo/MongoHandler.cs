using System.Collections.Generic;
using Hour_Logging_System.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace Hour_Logging_System.Mongo
{
    public class MongoHandler
    {
        private static string ConnectionString { get; } = "mongodb://hourlogging:DxyZ9gQYWqyj722m@luke-else.com/hourlogging?authDatabase=hourlogging&retryWrites=true&w=majority";
        private MongoClient Client { get; set; } = new MongoClient(ConnectionString);


        //Database Methods
        public bool Insert(Employee employee)
        {
            var database = Client.GetDatabase("hourlogging");
            var collection = database.GetCollection<Employee>("employees");
            

            var list = collection.Find(x => x.FirstName == employee.FirstName && x.LastName == employee.LastName).ToList();

            if (list.Count == 0)
            {
                collection.InsertOne(employee);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Insert(Manager manager)
        {
            var database = Client.GetDatabase("hourlogging");
            var collection = database.GetCollection<Manager>("managers");

            var list = collection.Find(x => x.FirstName == manager.FirstName && x.LastName == manager.LastName).ToList();

            if (list.Count == 0)
            {
                collection.InsertOne(manager);
                return true;
            }
            else
            {
                return false;
            }

        }





        //Pass in an employee with First, Last and password filled in in order to get a returned object that has hours and company filled.
        public Employee Get(Employee employee)
        {

            var database = Client.GetDatabase("hourlogging");
            var collection = database.GetCollection<Employee>("employees");
            var list = collection.Find(x => x.Username == employee.Username).ToList();

            if(list.Count == 0)
            {//Return null if there was no employee found.
                return null;
            }
            else
            {//return the first (Only) Employee object found.
                return list[0];
            }

        }

        //Pass in a manager object with password and get back a filled object if one is found.
        public Manager Get(Manager manager)
        {

            var database = Client.GetDatabase("hourlogging");
            var collection = database.GetCollection<Manager>("managers");
            var list = collection.Find(x =>
                                        x.FirstName == manager.FirstName &&
                                        x.LastName == manager.LastName &&
                                        x.Password == manager.Password
                                        ).ToList();

            if (list.Count == 0)
            {//Return null if there was no Manager found.
                return null;
            }
            else
            {//return the first (Only) Manager object found.
                return list[0];
            }

        }

        public void Update(Employee employee)
        {
            var database = Client.GetDatabase("hourlogging");
            var collection = database.GetCollection<Employee>("employees");

            collection.ReplaceOne(x => x.Username == employee.Username, employee);
        }

        public void Delete()
        {

        }

    }
}
