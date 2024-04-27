using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem_MVC_14042024.Models
{
    public class PublisherWrapper
    {
        public List<PublisherModel> publishers { set; get; }
        public Pager pager { get; set; }
    }
}