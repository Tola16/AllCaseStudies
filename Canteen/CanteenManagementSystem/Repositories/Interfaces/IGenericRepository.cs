using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CanteenManagementSystem.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        void Save();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAll();
    }
}
