using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface IActorsService
    {
        //metoda qe i kthen krejt aktort
        Task<IEnumerable<Actor>> GetAll();
        //metoda qe e kthen veq ni aktor
        Actor GetActorById(int id);
        //metoda per me add nje actor
        void Add(Actor actor);
        //update metoda
        Actor update(int id, Actor newActor);
        //delete metoda
        void Delete(int id);
    }
}
