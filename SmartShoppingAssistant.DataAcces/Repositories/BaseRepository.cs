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
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }


        public async Task<TEntity> UpdateAsync(TEntity entity )
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
