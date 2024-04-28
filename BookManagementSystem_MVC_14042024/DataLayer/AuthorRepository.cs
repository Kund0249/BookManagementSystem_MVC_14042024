using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;

namespace BookManagementSystem_MVC_14042024.DataLayer
{
    public class AuthorRepository
    {
        private readonly DataContext context;
        public AuthorRepository()
        {
            context = new DataContext();
        }
        public List<AuthorEntity> GetAuthors
        {
            get
            {
                return context.Author.ToList();
            }
        }
    }
}