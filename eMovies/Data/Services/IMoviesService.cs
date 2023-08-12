using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {
    }
}
