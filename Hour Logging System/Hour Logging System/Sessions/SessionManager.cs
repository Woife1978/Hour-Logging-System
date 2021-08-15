using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hour_Logging_System.Models;
using Microsoft.AspNetCore.Http;
using Hour_Logging_System.Mongo;
using Microsoft.AspNetCore;

namespace Hour_Logging_System.Sessions
{
    public class SessionManager
    {

        //Reload the user to ensure that we are operating on the most up to data version of the user.
        public Employee ReloadUser(Employee currentUser)
        {
            MongoHandler db = new MongoHandler();
            Employee reloadedUser = db.Get(currentUser);

            return currentUser;

        }

        public Manager ReloadUser(Manager currentUser)
        {
            MongoHandler db = new MongoHandler();
            Manager reloadedUser = db.Get(currentUser);

            return currentUser;

        }
    }
}
