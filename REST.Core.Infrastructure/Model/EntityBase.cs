using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace REST.Core.Infrastructure.Model
{
    public abstract class EntityBase<TId> : IEntity<TId>
    {
        #region Fields
        protected TId _id;

        protected IList<ValidationRule> _brokenRules;

        protected OnOffStateEnum _changesNotificatorState;
        #endregion

        #region Properties
        public TId Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsDirty { get; set; }

        public OnOffStateEnum ChangesNotificatorState
        {
            get
            {
                return _changesNotificatorState;
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected abstract void Validate();

        protected void AddBrokenRule(ValidationRule brokenRule)
        {
            _brokenRules.Add(brokenRule);
        }

        public IList<ValidationRule> GetBrokenRules()
        {
            _brokenRules.Clear();

            Validate();

            return _brokenRules;
        }

        public void Clean()
        {
            this.IsDirty = false;
        }

        public void TurnOnChangesNotificator()
        {
            _changesNotificatorState = OnOffStateEnum.On;
        }

        public void TurnOffChangesNotificator()
        {
            _changesNotificatorState = OnOffStateEnum.Off;
        }

        public override bool Equals(object entity)
        {
            return ((entity != null) && (entity is EntityBase<TId>) && (this == (EntityBase<TId>)entity));
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id == null && entity2.Id == null)
            {
                return false;
            }

            if (entity1.Id == null || entity2.Id == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (ChangesNotificatorState == OnOffStateEnum.On && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChange(object sender, EventArgs e)
        {
            this.IsDirty = true;
        }
        #endregion

        #region Constructors
        public EntityBase()
        {
            _changesNotificatorState = OnOffStateEnum.On;

            _brokenRules = new List<ValidationRule>();

            this.PropertyChanged += new PropertyChangedEventHandler(this.OnPropertyChange);
        }
        #endregion
    }
}
