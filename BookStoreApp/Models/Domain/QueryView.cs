using BookStoreApp.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

public class QueryViewModel
{
    public int? GenreId { get; set; }
    public int? AuthorId { get; set; }
    public int? PublisherId { get; set; }

    public List<SelectListItem>? GenreList { get; set; }
    public List<SelectListItem>? AuthorList { get; set; }
    public List<SelectListItem>? PublisherList { get; set; }

    public List<Book>? Books { get; set; } //after query the model will have a list of Books to showcase on QueryResult.cshtml
}