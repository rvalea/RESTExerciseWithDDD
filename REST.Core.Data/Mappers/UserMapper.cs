using REST.Core.Business;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;

namespace REST.Core.Data
{
    public static class UserMapper
    {
        public static IUser ConvertToUser(this OracleDataReader reader)
        {
            IUser user = new User();

            user.TurnOffChangesNotificator();

            user.Id = (Nullable<long>)(reader["USER_ID"] as Nullable<decimal>);

            user.Name = (reader["USER_NAME"] as string);

            user.Birthdate = reader.ReadNullableDateTime("BIRTHDAY_DATE").Value;

            user.TurnOnChangesNotificator();

            return user;
        }

        public static OBJ_USER ConvertToOBJ_USER(this User user)
        {
            var obj = new OBJ_USER();

            if (user.Id.HasValue)
            {
                obj.USER_ID = (decimal)user.Id.Value;
                obj.USER_IDIsNull = false;
            }

            obj.USER_NAME = user.Name;

            if (user.Birthdate != null)
            {
                obj.BIRTHDAY_DATE = user.Birthdate;
                obj.BIRTHDAY_DATEIsNull = false;
            }

            return obj;
        }
    }
}
