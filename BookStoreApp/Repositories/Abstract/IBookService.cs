using BookStoreApp.Models;
using BookStoreApp.Models.Domain;

namespace BookStoreApp.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int id);
        Book FindById(int id);
        IEnumerable<Book> GetAll();

        IEnumerable<Book> GetQueryResult(QueryViewModel model);
    }
}
