using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        public Task<SaveViewModel> AddAsync(SaveViewModel vm);
        public Task<List<ViewModel>> GetAllAsync();
        public Task<ViewModel> GetByIdAsync(int Id);
        public Task<SaveViewModel> GetByIdSaveViewModelAsync(int Id);
        public Task UpdateAsync(SaveViewModel vm, int Id);
        Task<List<ViewModel>> FindAllAsync(Expression<Func<Entity, bool>> filter);
        public Task Delete(int Id);
    }
}
