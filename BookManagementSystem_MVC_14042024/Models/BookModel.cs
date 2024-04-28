using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem_MVC_14042024.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase BookImage { get; set; }
        public int AuthorId { get; set; }
        public List<SelectListItem> Authors { get; set; }

        public static BookEntity Convert(BookModel model)
        {
            return new BookEntity()
            {
                Name = model.Name,
                AuthorId = model.AuthorId,
                IsActive = model.IsActive,
                ISBN = model.ISBN,
                ImageUrl = model.ImageUrl,
                BookId = model.BookId
            };
        }
    }
}