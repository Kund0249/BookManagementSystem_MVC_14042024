using BookManagementSystem_MVC_14042024.DataLayer;
using BookManagementSystem_MVC_14042024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem_MVC_14042024.Controllers
{
    public class BookController : BaseController
    {
        private readonly AuthorRepository authorRepository;
        private readonly BookRepository bookRepository;

        public BookController()
        {
            authorRepository = new AuthorRepository();
            bookRepository = new BookRepository();
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            BookModel model = new BookModel()
            {
                Authors = authorRepository.GetAuthors.
                            Select(x => new SelectListItem()
                            {
                                Text = x.Name,
                                Value = x.AuthorId.ToString()
                            }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookModel model)
        {
           if(model.BookImage != null)
            {
                string folderPath = @"~/Content/BookImage";
                string ServerFolderPath = Server.MapPath(folderPath);
                string FileName = Guid.NewGuid().ToString() + "_" + model.BookImage.FileName;
                string FilePath = System.IO.Path.Combine(ServerFolderPath, FileName);
                model.BookImage.SaveAs(FilePath);
                model.ImageUrl = FileName;

                if (bookRepository.AddBook(BookModel.Convert(model)))
                {
                    Notify("Success", "Book Created!", NotificationType.success);
                    ModelState.Clear();
                }
                else
                {
                    Notify("Error", "There is some proble,!", NotificationType.error);
                }
            }

            model.Authors = authorRepository.GetAuthors.
                       Select(x => new SelectListItem()
                       {
                           Text = x.Name,
                           Value = x.AuthorId.ToString()
                       }).ToList();
            
            return View(model);
        }
    }
}