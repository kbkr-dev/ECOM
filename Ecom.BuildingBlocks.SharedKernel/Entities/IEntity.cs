using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.BuildingBlocks.SharedKernel.Entities
{
    public interface IEntity
    {
        List<INotification> DomainEvents { get; }
    }
}
