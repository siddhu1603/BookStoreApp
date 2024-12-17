using BookStoreApp.Repositories.Abstract;
using BookStoreApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService; //Also conforms to the OCP principle. for open to extension and close to modification
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;
        public BookController(IBookService bookService, IPublisherService publisherService, IGenreService genreService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.publisherService = publisherService;
            this.genreService = genreService;
            this.authorService = authorService;
        }
        public IActionResult Add() //No attribute attached so a GET by default, genre/Add will return this by default
        {                          //populating the author, pub and genre list as these hv to be shown at add book page to choose frm these lists
            var model = new Book();
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString()}).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString()}).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString()}).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model) //since it is a POST Method this will be invoked when we submit the ADD FORM
        {                                     //whatever values we fill in form will be automatically available in the "model" by the MVC binding system
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);           //showcases the same form again in case of validation errors.
            }
            var result = bookService.Add(model);  //This Add method is from IGenreService, DI being used here.
            if (result == true)
            {
                TempData["msg"] = "Added Successfully";  //Initially null but after form submission will either have success/fail msg
                return RedirectToAction(nameof(Add));    //redirect to the same page
            }
            TempData["msg"] = "Error Has Occured";
            return View(model);                          //in case of err (DB side etc), the same form disp again with fail msg
        }

        public IActionResult Update(int id)
        {
            var model = bookService.FindById(id);
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Update(model);
            if (result == true)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error Has Occured";
            return View(model);
        }

        public IActionResult Delete(int id)
        //By default treated as a GET request and thus when we attach a [HttpDelete] attribute on top, the page breaks.
        {
            var result = bookService.Delete(id);

            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = bookService.GetAll();  //retrieving all the Genres from DB, method defined in GenreService (Dependency Injection)

            return View(data);  //since view name not mentioned the ctlr searches for View with same method name (GetAll.cshtml)


        }
        //when the "Query" link is clicked then user sees the Query.cshtml page where we pass the QueryViewModel to store the choices of user
        public IActionResult Query()         
        {
            var model = new QueryViewModel //we populate the resp lists and show on the Query.cshtml page.
            {
                GenreList = genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.Id.ToString() }).ToList(),
                AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString() }).ToList(),
                PublisherList = publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.Id.ToString() }).ToList()
            };
            return View(model); //This model is passed onto the Query.cshtml page.
        }

        [HttpPost]
        public IActionResult Query(QueryViewModel model)   //This model now contains the choices we have chosen on the Query.cshtml page
        {
            var books = bookService.GetQueryResult(model); //we then retrieve from DB the books that match this criteria
            model.Books = (List<Book>?)books;                  

            return View("QueryResult", model);             //return this model with the List of retrieved books to QueryResult.cshtml
        }
    }
}