using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApp.Repositories.Implementation
{
    public class GenreService : IGenreService //In this services class we provide implementation to the interface ka methods.
    {
        private readonly DatabaseContext context;

        public GenreService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Genre model)
        {
            try
            {
                context.Genres.Add(model);
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

                context.Genres.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Genre FindById(int id)
        {
            return context.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                context.Genres.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
