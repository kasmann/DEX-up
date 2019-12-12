using System;

namespace Unit17
{
    public static class IntExtensions
    {
        public static TimeSpan Seconds(this int value)
        {
            return TimeSpan.FromSeconds(value);
        }
        
        public static TimeSpan Minutes(this int value)
        {
            return TimeSpan.FromMinutes(value);
        }
        
        public static TimeSpan Hours(this int value)
        {
            return TimeSpan.FromHours(value);
        }
    }
}