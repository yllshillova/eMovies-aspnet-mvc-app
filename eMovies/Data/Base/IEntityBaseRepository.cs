using eMovies.Models;
using System.Linq.Expressions;

namespace eMovies.Data.Base
{
    //this code defines a generic interface IEntityBaseRepository<T> that is meant to serve as a base contract for repositories handling entities
    //that implement or derive from the IEntityBase interface.
    //IEntityBase: Ky kufizim tregon që tipi T duhet të implementojë interface IEntityBase.
    //Kjo do të thotë që tipi T duhet të jetë një entitet i bazuar në këtë interface.
    //new (): Ky kufizim tregon që tipi T duhet të jetë një tip i njohur dhe duhet të jetë në gjendje të krijohet me një konstruktor pa parametra.
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //metoda qe i kthen krejt listen e ni entiteti t caktum
        Task<IEnumerable<T>> GetAllAsync();
        //metoda e cila kthen krejt listen e ni entiteti qe ka relacione me entitete tjera
        //deklarimi i tipit te parametrit
        //PRA Ky tip është një varg i tipit Expression<Func<T, object>>,
        //që është një funksion lambda që merr një parameter të tipit T dhe kthen një objekt të tipit object.
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        //metoda qe e kthen veq ni pjestar t ni liste t entiteti
        Task<T> GetByIdAsync(int id);
        //metoda per me add nje pjestar ne nje entitet
        Task AddAsync(T entity);
        //update metoda
        Task UpdateAsync(int id, T entity);
        //delete metoda
        Task DeleteAsync(int id);
    }
}
