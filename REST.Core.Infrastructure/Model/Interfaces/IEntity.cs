using System.Collections.Generic;
using System.ComponentModel;

namespace REST.Core.Infrastructure.Model
{
    public interface IEntity
    {
        bool IsDirty { get; set; }

        OnOffStateEnum ChangesNotificatorState { get; }

        void Clean();

        void TurnOnChangesNotificator();

        void TurnOffChangesNotificator();

        IList<ValidationRule> GetBrokenRules();
    }

    public interface IEntity<TId> : IEntity, INotifyPropertyChanged
    {
        TId Id { get; set; }
    }
}
