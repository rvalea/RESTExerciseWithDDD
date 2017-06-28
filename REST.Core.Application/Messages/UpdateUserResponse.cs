using REST.Core.Infrastructure.Messaging;

namespace REST.Core.Application
{
    public class UpdateUserResponse : ResponseBase
    {
        public UserViewModel User { get; set; }
    }
}