using System.Collections.Generic;
using REST.Core.Infrastructure.Messaging;

namespace REST.Core.Application
{
    public class GetAllUsersResponse : ResponseBase
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}