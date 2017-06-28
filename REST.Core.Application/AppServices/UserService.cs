using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REST.Core.Business;
using REST.Core.Infrastructure.ComponentManagement;

namespace REST.Core.Application
{
    public class UserService : IUserService
    {
        #region Fields

        private IUserRepository _userRepository;

        #endregion

        #region Constructors

        public UserService()
            : this(ComponentManagerFactory.GetComponentManager().GetInstance<IUserRepository>())
        { }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region IUserService Members

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();

            try
            {
                User userToCreate = request.User.ConvertToUser();

                _userRepository.Add(userToCreate);

                response.User = userToCreate.ConvertToUserViewModel();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();

            try
            {
                User userToUpdate = _userRepository.GetById(request.User.UserId.Value);
                userToUpdate = request.User.ConvertToUser(userToUpdate);

                _userRepository.Save(userToUpdate);

                response.User = userToUpdate.ConvertToUserViewModel();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response = new DeleteUserResponse();

            try
            {
                User userToDelete = new User();
                userToDelete.Id = request.UserId;
                _userRepository.Remove(userToDelete);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public GetUserByIdResponse GetUserById(GetUserByIdRequest request)
        {
            GetUserByIdResponse response = new GetUserByIdResponse();

            try
            {
                User user = _userRepository.GetById(request.UserId);
                if (user != null)
                {
                    response.User = user.ConvertToUserViewModel();
                    response.Success = true;
                }
                else
                {
                    response.Message = "User not found";
                    response.Success = false;
                }                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public GetAllUsersResponse GetAllUsers(GetAllUsersRequest request)
        {
            GetAllUsersResponse response = new GetAllUsersResponse();

            try
            {
                var users = _userRepository.GetAll();

                response.Users = users.ConvertToUsersViewModels();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        #endregion
    }
}
