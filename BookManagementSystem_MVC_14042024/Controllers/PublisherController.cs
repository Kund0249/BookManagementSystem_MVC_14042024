using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagementSystem_MVC_14042024.Models;
using BookManagementSystem_MVC_14042024.DataLayer;

namespace BookManagementSystem_MVC_14042024.Controllers
{
    public class PublisherController : Controller
    {
        //Action Method
        //1 => Public
        //2 => Non-Static
        //3 => Can't Overloaded

        private readonly PublisherRepository _publisherRepository;
        public PublisherController()
        {
            _publisherRepository = new PublisherRepository();
        }
         
        [HttpGet] //http verbs
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(PublisherModel model)
        {
           
            if (_publisherRepository.Save(PublisherModel.Convert(model)))
            {
                ModelState.Clear();
            }
            return View(model);
        }
    }
}