using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using REST.Core.Application;
using REST.Core.Infrastructure.ComponentManagement;
using System.Net.Http;

namespace REST.Presentation.Web
{
    public class UsersController : ApiController
    {
        #region Fields
        private IUserService _userService;
        #endregion

        #region Constructor
        public UsersController()
            : this(ComponentManagerFactory.GetComponentManager().GetInstance<IUserService>())
        { }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        [HttpPost()]
        public IHttpActionResult CreateUser(UserViewModel userViewModel)
        {
            CreateUserRequest createUserRequest = new CreateUserRequest();
            REST.Core.Application.UserViewModel user = new REST.Core.Application.UserViewModel();

            user.UserName = userViewModel.Name;
            user.BirthDate = userViewModel.BirthDate.Value;

            createUserRequest.User = user;

            var response = _userService.CreateUser(createUserRequest);

            if (response.Success)
            {

                return Ok(response.User);
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            GetAllUsersRequest getAllUsersRequest = new GetAllUsersRequest();

            var response = _userService.GetAllUsers(getAllUsersRequest);

            if (response.Success)
            {
                if (response.Users == null)
                {
                    return NotFound();
                }
                else
                {                    
                    return Ok(response.Users);
                }
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            GetUserByIdRequest getUserByIdRequest = new GetUserByIdRequest();
            getUserByIdRequest.UserId = id;

            var response = _userService.GetUserById(getUserByIdRequest);

            if (response.Success)
            {
                if (response.User == null)
                {
                    return NotFound();
                }
                else
                { 
                    return Ok(response.User); 
                }
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpPut()]
        public IHttpActionResult Update(UserViewModel userViewModel)
        {
            UpdateUserRequest updateUserRequest = new UpdateUserRequest();

            REST.Core.Application.UserViewModel user = new REST.Core.Application.UserViewModel();

            user.UserId = userViewModel.Id;
            user.UserName = userViewModel.Name;
            user.BirthDate = userViewModel.BirthDate.Value;

            updateUserRequest.User = user;

            var response = _userService.UpdateUser(updateUserRequest);

            if (response.Success)
            {
                return Ok(response.User);
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpDelete()]
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

    }
}
