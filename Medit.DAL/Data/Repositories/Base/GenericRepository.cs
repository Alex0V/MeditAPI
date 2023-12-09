using Medit.DAL.Context;
using Medit.DAL.Entities.Base;
using Medit.DAL.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Data.Repositories.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity, new()
    {
        protected readonly MeditDBContext context;
        private DbSet<T> table;
        public bool AutoSaveChanges { get; set; } = true;

        public GenericRepository(MeditDBContext dbContext)
        {
            this.context = dbContext;
            table = context.Set<T>();
        }

        public async void Delete(int id)
        {
            var entity = table.SingleOrDefault(s => s.Id == id);
            table.Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task Insert(T obj)
        {
            table.Add(obj);
            await context.SaveChangesAsync();
        }

        public async void Update(T obj)
        {
            var entity = table.SingleOrDefault(s => s.Id == obj.Id);
            table.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
