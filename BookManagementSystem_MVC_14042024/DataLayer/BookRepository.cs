using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;
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

        public bool AddBook(BookEntity entity)
        {
            try
            {
                context.Books.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}