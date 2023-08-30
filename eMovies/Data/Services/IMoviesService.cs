using eMovies.Data.Base;
using eMovies.Data.ViewModels;
using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
