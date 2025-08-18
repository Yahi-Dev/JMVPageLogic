﻿using System.Linq.Expressions;

namespace JMVPageLogic.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task UpdateAsync(Entity entity, int Id);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GeEntityByIDAsync(int Id);
        Task<List<Entity>> FindAllAsync(Expression<Func<Entity, bool>> filter);
        Task<bool> ExistsAsync(Expression<Func<Entity, bool>> filter);
        Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);
    }
}
