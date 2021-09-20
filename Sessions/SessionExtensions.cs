﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hour_Logging_System.Sessions
{ 
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {//Sets the object of a session to Object
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {//Gets a session of known type (T)
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
