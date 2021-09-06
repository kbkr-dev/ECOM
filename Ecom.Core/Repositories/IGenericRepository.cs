using Ecom.BuildingBlocks.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Repositories
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll(bool noTracking = true);
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        Task SaveAsync();

        void Remove(IEnumerable<T> entitiesToRemove);
    }
}
