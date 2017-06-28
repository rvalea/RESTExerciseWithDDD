using System;
using REST.Core.Infrastructure.Model;

namespace REST.Core.Business
{
    public interface IUser : IEntity<Nullable<long>>
    {
        string Name { get; set; }

        DateTime Birthdate { get; set; }
    }
}