using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;

namespace BookManagementSystem_MVC_14042024.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext():base("name=DbCon")
        {

        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }
    }
}