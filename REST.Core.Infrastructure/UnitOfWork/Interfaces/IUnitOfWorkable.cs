using REST.Core.Infrastructure.Model;
using System.Collections.Generic;
using System.Data;

namespace REST.Core.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkable
    {
        void Add(IDbConnection connection, object unitOfWorkMember);

        void Save(IDbConnection connection, object unitOfWorkMember);

        void Remove(IDbConnection connection, object unitOfWorkMember);
    }
}