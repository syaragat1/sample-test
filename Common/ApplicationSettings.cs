using System;

namespace Common
{
    internal class ApplicationSettings
    {
        public static string RmqConnectionString => "host=localhost;";
        public static string SqlConnectionString => throw new NotImplementedException("Specify SQL connection string");
        
    }
}
