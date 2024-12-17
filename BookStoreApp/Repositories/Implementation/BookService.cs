using BookStoreApp.Models;
using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext context;

        public BookService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Book model)
        {
            try
            {
                context.Books.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);

                if (data == null)
                {
                    return false;
                }

                context.Books.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in context.Books 
                        join author in context.Authors on book.AuthorId equals author.Id
                        join publisher in context.Publishers on book.PublisherId equals publisher.Id
                        join genre in context.Genres on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            GenreId = book.GenreId,
                            PublisherId = book.PublisherId,
                            ISBN = book.ISBN,                            
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName
                        }
                        ).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                context.Books.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Book> GetQueryResult(QueryViewModel model) //the model received from Query.cshtml page with user's choices.
        {
            if (model.GenreId == null && model.AuthorId == null && model.PublisherId == null)
            {
                return new List<Book>();
            } 

            var books = (from book in context.Books
                         join author in context.Authors on book.AuthorId equals author.Id
                         join publisher in context.Publishers on book.PublisherId equals publisher.Id
                         join genre in context.Genres on book.GenreId equals genre.Id
                         select new Book
                         {
                             Id = book.Id,
                             AuthorId = book.AuthorId,
                             GenreId = book.GenreId,
                             PublisherId = book.PublisherId,
                             ISBN = book.ISBN,
                             Title = book.Title,
                             TotalPages = book.TotalPages,
                             GenreName = genre.Name,
                             AuthorName = author.AuthorName,
                             PublisherName = publisher.PublisherName
                         }
                        ).Where(b =>
                            (model.GenreId == null || b.GenreId == model.GenreId) &&
                            (model.AuthorId == null || b.AuthorId == model.AuthorId) &&
                            (model.PublisherId == null || b.PublisherId == model.PublisherId))
                            .ToList();

            return books;
        }
    }
}


