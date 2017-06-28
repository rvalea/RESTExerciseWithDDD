using System.Collections.Generic;
using REST.Core.Business;
using REST.Core.Infrastructure.Model;
using System.Linq;

namespace REST.Core.Application
{
    internal static class UserMapper
    {
        #region Methods
        public static UserViewModel ConvertToUserViewModel(this User user)
        {
            UserViewModel userViewModel = new UserViewModel();

            userViewModel.UserId = user.Id;
            userViewModel.UserName = user.Name;
            userViewModel.BirthDate = user.Birthdate;

            return userViewModel;
        }

        internal static User ConvertToUser(this UserViewModel userViewModel)
        {
            User user = new User();

            user.Id = userViewModel.UserId;
            user.Name = userViewModel.UserName;

            if (userViewModel.BirthDate != null)
            {
                user.Birthdate = userViewModel.BirthDate.Value;
            }

            return user;
        }

        internal static User ConvertToUser(this UserViewModel userViewModel, User user)
        {
            user.Name = userViewModel.UserName;
            user.Birthdate = userViewModel.BirthDate.Value;

            return user;
        }

        public static IEnumerable<UserViewModel> ConvertToUsersViewModels(this IEnumerable<User> users)
        {
            return (from u in users select u.ConvertToUserViewModel()).ToList();
        }

        #endregion
    }
}