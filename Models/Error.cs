using System;

namespace Hour_Logging_System.Models
{
    public class Error
    {
        public string ErrorMessage { get; set; }

        public TempValues[] TempValues { get; set; }

    }

    public class TempValues
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
