using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entprog.DataModel
{
    public interface IGenRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<bool> Exists(int id);
        Task<T> GetAsync(int id);
    }
}
