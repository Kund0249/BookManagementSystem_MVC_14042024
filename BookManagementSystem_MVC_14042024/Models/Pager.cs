using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManagementSystem_MVC_14042024.Models
{
    public class Pager
    {
        public int CurrentPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TotalPage { get; set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}