
using System;

namespace FlightReservationSystem.Model.Entity
{

    public interface IEntity
    {

    }

    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }

        public EntityBase() 
        { 

        }

        public EntityBase(bool initialize)
        {
            if (initialize)
            {
                Initialize();
            }

        }

        public void Initialize()
        {
            Id = Guid.NewGuid();
            OnInitialize();
        }
        public virtual void OnInitialize()
        {

        }
    }
}