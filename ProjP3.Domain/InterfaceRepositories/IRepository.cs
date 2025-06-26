using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    internal interface IRepository
    {
        Task<bool> SaveAllAsync();
        Task<bool> DeleteAsync(ulong id);
        Task<bool> ExistsAsync(ulong id);
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<T> GetByIdAsync<T>(ulong id) where T : class;
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
    }
}
