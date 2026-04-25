using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartShoppingAssistant.DataAcces.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SmartShoppingAssistantDbContext _context;

        public BaseRepository(SmartShoppingAssistantDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);

                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found.");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the entity: {ex.Message}");
            }

            
           
        }
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found.");
                }
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the entity: {ex.Message}");
        }
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
