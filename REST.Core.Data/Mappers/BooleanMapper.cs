using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Core.Data
{
    public static class BooleanMapper
    {
        public static Nullable<bool> ConvertToNullableBool(this string value)
        {
            if (value == null)
                return null;
            else if (value == "Y")
                return true;
            else if (value == "N")
                return false;
            else
                throw new ArgumentOutOfRangeException("value");
        }

        public static bool ConvertToBool(this string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            else if (value.ToUpper() == "Y")
                return true;
            else if (value.ToUpper() == "N")
                return false;
            else
                throw new ArgumentOutOfRangeException("value");
        }

        public static string ConvertToString(this Nullable<bool> value)
        {
            if (value == null)
                return null;
            else
                return (value.Value ? "Y" : "N");
        }

        public static string ConvertToString(this bool value)
        {
            return (value ? "Y" : "N");
        }
    }
}
