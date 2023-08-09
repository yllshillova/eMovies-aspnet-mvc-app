using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface IActorsService
    {
        //metoda qe i kthen krejt aktort
        Task<IEnumerable<Actor>> GetAllAsync();
        //metoda qe e kthen veq ni aktor
        Task<Actor> GetActorByIdAsync(int id);
        //metoda per me add nje actor
        Task AddAsync(Actor actor);
        //update metoda
        Task<Actor> UpdateAsync(int id, Actor newActor);
        //delete metoda
        Task DeleteAsync(int id);
    }
}
