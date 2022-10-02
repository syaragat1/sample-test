using System;

namespace Common
{
    internal class ApplicationSettings
    {
        public static string RmqConnectionString => "host=localhost;";
        public static string SqlConnectionString => "Server=.;Database=NSBTest;Trusted_Connection=True;";
        
    }
}
