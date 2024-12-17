using BookStoreApp.Repositories.Abstract;
using BookStoreApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;     
        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }
        public IActionResult Add() //No attribute attached so a GET by default, genre/Add will return this by default
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model) //since it is a POST Method this will be invoked when we submit the ADD FORM
        {                                     //whatever values we fill in form will be automatically available in the "model" by the MVC binding system
            if (!ModelState.IsValid)
            {
                return View(model);           //showcases the same form again in case of validation errors.
            }
            var result = service.Add(model);  //This Add method is from IGenreService, DI being used here.
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
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
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
            var result = service.Delete(id);

            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = service.GetAll();  //retrieving all the Genres from DB, method defined in GenreService (Dependency Injection)

            return View(data);  //since view name not mentioned the ctlr searches for View with same method name (GetAll.cshtml)
                                //the model is also passed with it which contains all teh retrieved authors.
        }

    }
}
