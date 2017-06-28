using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using REST.Core.Application;
using REST.Core.Infrastructure.ComponentManagement;

namespace REST.Core.Presentation.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        #region Fields
        private IUserService _userService;
        #endregion

        #region Constructor
        public UserController()
        {
            _userService = ComponentManagerFactory.GetComponentManager().GetInstance<IUserService>();
        }
        #endregion

        #region Methods
        public IHttpActionResult CreateUser(UserViewModel userViewModel)
        {
            CreateUserRequest createUserRequest = new CreateUserRequest();
            Application.UserViewModel user = new Application.UserViewModel();

            user.UserName = userViewModel.Username;
            user.BirthDate = userViewModel.BirthDate.Value;

            createUserRequest.User = user;

            var response = _userService.CreateUser(createUserRequest);

            if (response.Success)
            {
                return Ok(response.UserId);
            }
            else
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult GetUserById(long id)
        {
            GetUserByIdRequest getUserByIdRequest = new GetUserByIdRequest();
            getUserByIdRequest.UserId = id;

            var response = _userService.GetUserById(getUserByIdRequest);

            if (response.Success)
            {
                return Ok(response.User);
            }
            else
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetAll()
        {
            GetAllUsersRequest getAllUsersRequest = new GetAllUsersRequest();

            var response = _userService.GetAllUsers(getAllUsersRequest);

            if (response.Success)
            {
                return Ok(response.Users);
            }
            else
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Update(UserViewModel userViewModel)
        {
            UpdateUserRequest updateUserRequest = new UpdateUserRequest();

            Application.UserViewModel user = new Application.UserViewModel();

            user.UserName = userViewModel.Username;
            user.BirthDate = userViewModel.BirthDate.Value;

            updateUserRequest.User = user;

            var response = _userService.UpdateUser(updateUserRequest);

            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(long id)
        {
            DeleteUserRequest deleteUserRequest = new DeleteUserRequest();
            deleteUserRequest.UserId = id;

            var response = _userService.DeleteUser(deleteUserRequest);

            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        #endregion
    }
}