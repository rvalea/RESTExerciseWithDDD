using System;
using System.ComponentModel;
using REST.Core.Infrastructure.Model;

namespace REST.Core.Business
{
    public class User : EntityBase<Nullable<long>>, IUser
    {
        #region Fields
        protected string _name;

        protected DateTime _birthdate;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Constructors
        public User()
        {
        }
        #endregion

        #region Methods
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                base.AddBrokenRule(new BusinessRule("UserName", "User Name Required"));
            }

            if (Birthdate == null)
            {
                base.AddBrokenRule(new BusinessRule("UserBirthdate", "User Birthdate Required"));
            }
        }
        #endregion
    }
}
