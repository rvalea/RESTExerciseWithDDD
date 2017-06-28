using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using REST.Core.Infrastructure.Model;

namespace REST.Core.Application
{
    public class UserViewModel
    {
        #region Properties

        public long? UserId { get; set; }

        public string UserName { get; set; }

        public DateTime? BirthDate { get; set; }

        #endregion

        #region Constructors

        public UserViewModel()
        {
        }

        #endregion
    }
}
