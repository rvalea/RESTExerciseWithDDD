using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using REST.Core.Infrastructure.Helpers;
using REST.Core.Infrastructure.Model;
using REST.Core.Business;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace REST.Core.Data
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        #region Constants
        private const string GETBYID_SP_NAME = "PKG_USER.p_get_by_id";

        private const string GETALL_SP_NAME = "PKG_USER.p_get_all";

        private const string COUNT_SP_NAME = "PKG_USER.p_count";

        private const string ADD_SP_NAME = "PKG_USER.p_ins";

        private const string SAVE_SP_NAME = "PKG_USER.p_upd";

        private const string REMOVE_SP_NAME = "PKG_USER.p_del";
        #endregion

        #region IReadOnlyRepository Members
        public long Count()
        {
            try
            {
                long count = 0;

                using (OracleConnection connection = new OracleConnection(base.ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand(COUNT_SP_NAME, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        OracleParameter userCountOutParam = new OracleParameter()
                        {
                            ParameterName = "p_count_o",
                            OracleDbTypeEx = OracleDbType.Decimal,
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(userCountOutParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        count = Convert.ToInt64(userCountOutParam.Value);
                    }
                }

                return count;

            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }
        #endregion

        #region IRepository Members
        public void Add(User user)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(base.ConnectionString))
                {
                    connection.Open();
                    OracleTransaction transaction = connection.BeginTransaction();
                    Add(connection, user);
                    transaction.Commit();
                }
            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }

        public void Save(User user)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(base.ConnectionString))
                {
                    connection.Open();
                    OracleTransaction transaction = connection.BeginTransaction();
                    Save(connection, user);
                    transaction.Commit();
                }
            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }

        public void Remove(User user)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(base.ConnectionString))
                {
                    connection.Open();
                    OracleTransaction transaction = connection.BeginTransaction();
                    Remove(connection, user);
                    transaction.Commit();
                }
            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }
        #endregion

        #region IUnitOfWorkable
        public void Add(IDbConnection connection, object unitOfWorkMember)
        {
            try
            {
                var oracleConnection = (OracleConnection)connection;

                var user = (User)unitOfWorkMember;

                EnsureThat.EntityIsValid(user);

                using (OracleCommand command = new OracleCommand(ADD_SP_NAME, oracleConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.BindByName = true;

                    OracleParameter userObjectInParam = new OracleParameter()
                    {
                        ParameterName = "pobj_user_i",
                        DbType = DbType.Object,
                        UdtTypeName = typeof(OBJ_USER).Name,
                        Direction = ParameterDirection.Input,
                        Value = user.ConvertToOBJ_USER()
                    };
                    command.Parameters.Add(userObjectInParam);

                    OracleParameter userIdOutParam = new OracleParameter()
                    {
                        ParameterName = "p_user_id_o",
                        OracleDbTypeEx = OracleDbType.Decimal,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(userIdOutParam);

                    command.ExecuteNonQuery();

                    user.Id = Convert.ToInt64(userIdOutParam.Value);
                }

                user.Clean();

                user.TurnOnChangesNotificator();
            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }

        public void Save(IDbConnection connection, object unitOfWorkMember)
        {
            try
            {
                var oracleConnection = (OracleConnection)connection;

                var user = (User)unitOfWorkMember;

                EnsureThat.EntityIsValid(user);

                if (user.IsDirty)
                {
                    using (OracleCommand command = new OracleCommand(SAVE_SP_NAME, oracleConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        OracleParameter userObjectInParam = new OracleParameter()
                        {
                            ParameterName = "pobj_user_i",
                            DbType = DbType.Object,
                            UdtTypeName = typeof(OBJ_USER).Name,
                            Direction = ParameterDirection.Input,
                            Value = user.ConvertToOBJ_USER()
                        };
                        command.Parameters.Add(userObjectInParam);

                        command.ExecuteNonQuery();
                    }

                    user.Clean();

                    user.TurnOnChangesNotificator();
                }
            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }

        public void Remove(IDbConnection connection, object unitOfWorkMember)
        {
            try
            {
                var user = (User)unitOfWorkMember;

                using (OracleCommand command = new OracleCommand(REMOVE_SP_NAME, (OracleConnection)connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.BindByName = true;

                    command.Parameters.Add("p_user_id_i",
                                           OracleDbType.Decimal,
                                           ParameterDirection.Input).Value = user.Id;

                    command.ExecuteNonQuery();
                }

                user.Clean();

            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }
        #endregion

        #region IUserRepository Members
        public User GetById(long id)
        {
            try
            {
                IUser user = null;

                using (OracleConnection connection = new OracleConnection(base.ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand(GETBYID_SP_NAME, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        command.Parameters.Add("p_user_id_i", OracleDbType.Decimal, ParameterDirection.Input).Value = id;

                        command.Parameters.Add("pcur_user_o", OracleDbType.RefCursor, ParameterDirection.Output);

                        connection.Open();
  
                        OracleDataReader dataReader = command.ExecuteReader();
                        user = BuildUser(connection, dataReader);
                    }
                }

                return (User)user;

            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                IEnumerable<IUser> userEnumerable = null;

                using (OracleConnection connection = new OracleConnection(base.ConnectionString))
                {
                    using (OracleCommand command = new OracleCommand(GETALL_SP_NAME, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.BindByName = true;

                        command.Parameters.Add("pcur_user_o", OracleDbType.RefCursor, ParameterDirection.Output);

                        connection.Open();
    
                        OracleDataReader dataReader = command.ExecuteReader();
                        userEnumerable = BuildUserEnumerable(connection, dataReader);
                    }
                }

                return userEnumerable.Cast<User>();

            }
            catch (OracleException oracleException)
            {
                throw oracleException.ConvertToDataLayerException();
            }
        }
        #endregion
        
        #region Methods
        private IUser BuildUser(OracleConnection connection, OracleDataReader dataReader)
        {
            IUser user = null;

            using (dataReader)
            {
                if (dataReader.Read())
                {
                    user = dataReader.ConvertToUser();                    
                }
            }

            return user;
        }

        private IEnumerable<IUser> BuildUserEnumerable(OracleConnection connection, OracleDataReader dataReader)
        {
            var userEnumerable = new List<IUser>();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    userEnumerable.Add(dataReader.ConvertToUser());
                }
            }

            return userEnumerable;
        }

        #endregion
    }
}