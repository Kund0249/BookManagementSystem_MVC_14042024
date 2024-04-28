using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystem_MVC_14042024.DataLayer.DataEntity
{
    [Table("TAUTHOR")]
    public class AuthorEntity
    {
        [Key]
        public int AuthorId { get; set; }

        [Column("AuthorName")]
        public string Name { get; set; }

        [Column("EmailAddress")]
        public string Email { get; set; }

        [Column("MobileNumber")]
        public string Mob { get; set; }
        public string Gender { get; set; }
    }
}