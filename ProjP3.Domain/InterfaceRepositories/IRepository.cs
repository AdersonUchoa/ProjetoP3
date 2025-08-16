using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Domain.InterfaceRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> SaveAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
