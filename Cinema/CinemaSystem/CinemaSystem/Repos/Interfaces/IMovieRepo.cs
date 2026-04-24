using CinemaSystem.Models;

namespace CinemaSystem.Repos.Interfaces
{

    public interface IMovieRepo : IGenericRepo<Movie>
    {
        List<Movie> Search(string name);
    }

}
