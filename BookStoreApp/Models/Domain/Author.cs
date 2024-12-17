using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models.Domain
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; } = null!;
      
    }
}