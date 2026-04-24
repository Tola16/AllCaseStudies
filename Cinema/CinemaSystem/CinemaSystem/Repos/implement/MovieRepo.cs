using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;


namespace CinemaSystem.Repos.implement
{
    public class MovieRepo : IMovieRepo
    {
        public readonly AppDbContext db;

        public MovieRepo(AppDbContext c)
        {
            db = c;
        }

        public void Add(Movie entity) => db.Add(entity);

        public void Delete(Movie entity) => db.Movies.Remove(entity);

        public List<Movie> GetAll() =>
            db.Movies.Include(a => a.ShowTime).ToList();

        public Movie GetById(int id) =>
            db.Movies.Include(a => a.ShowTime)
                     .FirstOrDefault(u => u.Id == id);

        public void save() => db.SaveChanges();

        public void Update(Movie entity) => db.Update(entity);

        public List<Movie> Search(string name)
        {
            var query = db.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Title.Contains(name));
            }


            return query.ToList();
        }
    }
}
