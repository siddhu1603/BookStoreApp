using BookStoreApp.Models.Domain;

namespace BookStoreApp.Repositories.Abstract
{
    public interface IGenreService //We def the services here & provide its implementation elsewhere, Loose coupling
    {                              //This is Method Dependency Injection
        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(int id);
        Genre FindById(int id);
        IEnumerable<Genre> GetAll();
    }
}
