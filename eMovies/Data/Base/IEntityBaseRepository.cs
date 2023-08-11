using eMovies.Models;

namespace eMovies.Data.Base
{
    //this code defines a generic interface IEntityBaseRepository<T> that is meant to serve as a base contract for repositories handling entities
    //that implement or derive from the IEntityBase interface.
    //It enforces that any class implementing this interface must be a reference type, implement the IEntityBase interface,
    //and have a parameterless constructor.
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        //metoda qe i kthen krejt aktort
        Task<IEnumerable<T>> GetAllAsync();
        //metoda qe e kthen veq ni aktor
        Task<T> GetByIdAsync(int id);
        //metoda per me add nje actor
        Task AddAsync(T entity);
        //update metoda
        Task UpdateAsync(int id, T entity);
        //delete metoda
        Task DeleteAsync(int id);
    }
}
