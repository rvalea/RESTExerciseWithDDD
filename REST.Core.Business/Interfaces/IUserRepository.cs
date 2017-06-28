using System;
using System.Collections.Generic;
using REST.Core.Infrastructure.Model;
using REST.Core.Infrastructure.UnitOfWork;

namespace REST.Core.Business
{
    public interface IUserRepository : IRepository<User, long>, IUnitOfWorkable
    {
        User GetById(long id);

        IEnumerable<User> GetAll();
    }
}