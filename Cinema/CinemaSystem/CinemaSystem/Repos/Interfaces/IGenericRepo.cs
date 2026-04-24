namespace CinemaSystem.Repos.Interfaces
{
    public interface IGenericRepo<T>
    {
        T GetById(int id);
        List<T> GetAll();

        void Add(T entity);
        void Update(T entity);
        void Delete(T Entity);
        void save();
    }
}


