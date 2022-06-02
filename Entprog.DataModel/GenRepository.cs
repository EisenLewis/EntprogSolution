using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entprog.DataModel
{
    public class GenRepository<T> : IGenRepository<T> where T : class
    {
        private readonly DbContext Context;
        public GenRepository(DbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await this.GetAsync(id);
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            T entity = await Context.Set<T>().FindAsync(id);
            if (entity == null)
                return false;
            else
                return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
