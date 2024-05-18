using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem_MVC_14042024.DataLayer.DataEntity
{
    [Table("TBOOKS")]
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }

        [Column("BookName")]
        public string Name { get; set; }
        public string ISBN { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        //Navigation Properties
        public AuthorEntity Author { get; set; }
    }
}