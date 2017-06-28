using System;
using Oracle.DataAccess.Client;

namespace REST.Core.Data
{
    public static class OracleDataReaderHelper
    {
        public static bool IsExistsColumn(this OracleDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                {
                    return true;
                }
            }
            return false;
        }

        public static DateTime? ReadNullableDateTime(this OracleDataReader reader, string columnName)
        {
            DateTime? result = null;

            if (reader.IsExistsColumn(columnName) && !(reader[columnName] is DBNull) && (reader[columnName] as Nullable<DateTime>).HasValue)
            {
                result = DateTime.SpecifyKind((DateTime)(reader[columnName] as Nullable<DateTime>), DateTimeKind.Utc);
            }

            return result;
        }

        public static DateTime ReadDateTime(this OracleDataReader reader, string columnName)
        {
            DateTime? result = ReadNullableDateTime(reader, columnName);

            return result ?? default(DateTime);
        }

        public static bool? ReadNullableBool(this OracleDataReader reader, string columnName)
        {
            bool? result = null;

            if (reader.IsExistsColumn(columnName))
            {
                result = (reader[columnName] as string).ConvertToNullableBool();
            }

            return result;
        }

        public static bool ReadBool(this OracleDataReader reader, string columnName)
        {
            bool? result = ReadNullableBool(reader, columnName);

            return result ?? default(bool);
        }

        public static decimal? ReadNullableDecimal(this OracleDataReader reader, string columnName)
        {
            decimal? result = null;

            if (reader.IsExistsColumn(columnName))
            {
                result = reader[columnName] as decimal?;
            }

            return result;
        }

        public static decimal ReadDecimal(this OracleDataReader reader, string columnName)
        {
            decimal? result = ReadNullableDecimal(reader, columnName);

            return result ?? default(decimal);
        }

        public static string ReadString(this OracleDataReader reader, string columnName)
        {
            string result = string.Empty;

            if (reader.IsExistsColumn(columnName))
            {
                result = reader[columnName] as string;
            }

            return result;
        }

        public static string ConvertNumberToString(this OracleDataReader reader, string columnName)
        {
            string result = string.Empty;

            if (IsExistsColumn(reader, columnName))
            {
                decimal? valueInDb = reader[columnName] as decimal?;

                if (valueInDb.HasValue)
                {
                    result = valueInDb.ToString();
                }
            }

            return result;
        }
    }
}
