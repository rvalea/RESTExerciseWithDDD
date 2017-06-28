using System;
using System.Configuration;
using REST.Core.Infrastructure.Model;

namespace REST.Core.Data
{
    public abstract class RepositoryBase
    {
        #region Properties
        protected string ConnectionString { get; set; }
        #endregion

        #region Constructors
        public RepositoryBase()
            : this(ConfigurationManager.ConnectionStrings["RestDatabase"].ConnectionString)
        {
        }

        public RepositoryBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        #endregion
    }
}
