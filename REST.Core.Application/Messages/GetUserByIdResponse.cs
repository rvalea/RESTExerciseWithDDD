using REST.Core.Infrastructure.Messaging;

namespace REST.Core.Application
{
    public class GetUserByIdResponse : ResponseBase
    {
        public UserViewModel User { get; set; }
    }
}