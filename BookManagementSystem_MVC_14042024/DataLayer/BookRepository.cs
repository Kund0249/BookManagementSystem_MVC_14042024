using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;
using BookManagementSystem_MVC_14042024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem_MVC_14042024.DataLayer
{
    public class BookRepository
    {
        private readonly DataContext context;
        public BookRepository()
        {
            context = new DataContext();
        }

        public List<BookModel> GetBooks
        {
            get
            {
               return context.Books.Select(x => new BookModel() { 
                BookId = x.BookId,
                Name = x.Name,
                ISBN = x.ISBN
                }).ToList();
            }
        }
        public bool AddBook(BookEntity entity)
        {
            try
            {
                context.Books.Add(entity);
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