using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Data.Services
{
    public class MoviesService: EntityBaseRepository<Movie>,IMoviesService
    {
        public MoviesService(AppDbContext context): base(context)
        {
        }
    }
}
