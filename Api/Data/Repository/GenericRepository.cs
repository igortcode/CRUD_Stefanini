using Business.Entities;
using Business.Interfaces.Repository;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApiDbContext Context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApiDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }
        
        public async Task<TEntity> Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
            return await _dbSet.FindAsync(entity.Id);
        }

        public async Task<TEntity> Atualizar(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
            
            return await _dbSet.FindAsync(entity.Id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            Context.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
