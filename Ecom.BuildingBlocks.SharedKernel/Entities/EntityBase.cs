using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.BuildingBlocks.SharedKernel.Entities
{
    public abstract class EntityBase: IEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        private List<INotification> _domainEvents;

        public List<INotification> DomainEvents => _domainEvents;

        public EntityBase() :this(Guid.NewGuid())
        {

        }

        protected EntityBase(Guid id)
        {
            Id = id;
            CreatedDate = DateTime.Now;
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
    }
}
