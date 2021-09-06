using Ecom.BuildingBlocks.SharedKernel.Entities;
using Ecom.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly EcomContext _ecomContext;
        private readonly IMediator _mediator;
        private DbSet<T> _entitySet;

        public GenericRepository(EcomContext ecomContext, IMediator mediator)
        {
            _ecomContext = ecomContext;
            _mediator = mediator;
            _entitySet = _ecomContext.Set<T>();
        }

        public IQueryable<T> GetAll(bool noTracking = true)
        {
            var set = _entitySet;
            if (noTracking)
            {
                return set.AsNoTracking();
            }

            return set;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entitySet.FirstOrDefaultAsync(e => e.Id == id) as T;
        }

        public async Task InsertAsync(T entity)
        {
            await _entitySet.AddAsync(entity);
        }

        public void Remove(IEnumerable<T> entitiesToRemove)
        {
            _entitySet.RemoveRange(entitiesToRemove);
        }

        public async Task SaveAsync()
        {
            // await DispatchDomainEvents();
            await _ecomContext.SaveChangesAsync();
        }

        private async Task DispatchDomainEvents()
        {
            var domainEntities = _ecomContext.ChangeTracker.Entries<IEntity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents != null && po.DomainEvents.Any());

            foreach(var entity in domainEntities)
            {
                foreach(var domainEvent in entity.DomainEvents)
                {
                    await _mediator.Publish(domainEntities);
                }
                entity.DomainEvents.Clear();
            }
        }
    }
}
