using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return Convert.ToInt32(input) >= 0;
        }
    }
}
