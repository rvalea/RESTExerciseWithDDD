using REST.Core.Infrastructure.Messaging;

namespace REST.Core.Application
{
    public class CreateUserResponse : ResponseBase
    {
        public UserViewModel User { get; set; }
    }
}