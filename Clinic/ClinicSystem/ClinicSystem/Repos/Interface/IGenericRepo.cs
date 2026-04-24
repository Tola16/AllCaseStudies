namespace ClinicSystem.Repos.Interface
{
    public interface IGenericRepo<T>
    {
        public List<T> GetAll();

        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Save();

    }
}
