using System;
using System.Collections.Generic;

namespace REST.Core.Infrastructure.Model
{
    public interface IReadOnlyRepository<T, TId> : IRepository
    {
        T GetById(TId id);

        IEnumerable<T> GetAll();

        long Count();
    }
}