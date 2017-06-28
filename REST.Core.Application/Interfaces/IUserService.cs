using System.ServiceModel;

namespace REST.Core.Application
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        
        CreateUserResponse CreateUser(CreateUserRequest request);

        [OperationContract]
        UpdateUserResponse UpdateUser(UpdateUserRequest request);

        [OperationContract]
        DeleteUserResponse DeleteUser(DeleteUserRequest request);

        [OperationContract]
        GetUserByIdResponse GetUserById(GetUserByIdRequest request);

        [OperationContract]
        GetAllUsersResponse GetAllUsers(GetAllUsersRequest request);
    }
}
