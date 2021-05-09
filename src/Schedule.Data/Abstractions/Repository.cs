using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schedule.Data.Context;
using Schedule.Domain.Abstractions;

namespace Schedule.Data.Abstractions
{
    public class Repository<TEntity, TContext> 
    where TEntity : Entity
    where TContext : ScheduleContext
    {
        TContext Context;
        DbSet<TEntity> Table;

        public Repository(TContext context)
        {
            Context = context;
            Table = GetTable();
        }
        
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null){

            var query = Table.AsQueryable();

            if(filter != null){
                query = query.Where(filter);
            }

            return query;
        }

        private DbSet<TEntity> GetTable(){

            DbSet<TEntity> mySet = Context.Set<TEntity>();
            return mySet;
        }

        public async Task<TEntity> InsertAsync(TEntity obj){
            await Table.AddAsync(obj);
            await Context.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            var result = await GetAll(e => e.Id == obj.Id).FirstOrDefaultAsync();
            
            Context.Entry(result).CurrentValues.SetValues(obj);
            await Context.SaveChangesAsync();
            return obj;
        }

        public async Task<TEntity> RemoveAsync(int id){

            var result = await GetAll(e => e.Id == id).FirstOrDefaultAsync();
            
            Table.Remove(result);
            await Context.SaveChangesAsync();
            return result;
        }
    }
}