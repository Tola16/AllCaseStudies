namespace SchoolSystem.Repos.Interface
{
    public interface IGenericRepo<T>
    {
        public List<T> GetAll();
        public T GetById (int id);
        public void Update(T entity);
        public void Add(T entity);
        public void Delete(T entity);
        public void Save();


    }
}
