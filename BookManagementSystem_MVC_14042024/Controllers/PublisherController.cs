using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagementSystem_MVC_14042024.Models;
using BookManagementSystem_MVC_14042024.DataLayer;
//using System.Web.Script.Serialization;

namespace BookManagementSystem_MVC_14042024.Controllers
{
    public class PublisherController : BaseController
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
        public ViewResult Index(int pageno = 1)
        {
            //int TotalRowPerPage = 5;
            //int TotalPage = 0;
            //int StarPage = 0;
            //int EndPage = 0;

            int totalrows;
            List<PublisherModel> models = _publisherRepository.
                                           GetPublishers(pageno, 5, out totalrows).
                                           Select(x => PublisherModel.Convert(x)).ToList();

            int TotalPage = (int)Math.Ceiling((double)totalrows / 5);

            //Pager pager = new Pager()
            //{
            //    CurrentPage = pageno,
            //    StartPage = Math.Max(1, Math.Min(pageno - 3, totalrows - 6)),
            //    EndPage = Math.Min(pageno+6,TotalPage),
            //    TotalPage = TotalPage
            //};

            Pager pager = new Pager()
            {
                CurrentPage = pageno,
                StartPage = (pageno <= 7 ? 1:pageno+1),
                EndPage = Math.Min((pageno <= 7 ? 7 : pageno + 7), TotalPage),
                TotalPage = TotalPage
            };

            PublisherWrapper wrapper = new PublisherWrapper()
            {
                publishers = models,
                pager = pager
            };
            return View(wrapper);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PublisherModel model)
        {
            if (_publisherRepository.Save(PublisherModel.Convert(model), out string StatusCode))
            {
                //var js = new JavaScriptSerializer();
                //var message = js.Serialize("Record Save Successfully!");
                //TempData["Message"] = message;
                Notify("Success", "Record Save Successfully!", NotificationType.success);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpGet] //http verbs
        public ActionResult Edit(int id)
        {
            PublisherModel model = PublisherModel.Convert(_publisherRepository.GetPublisher(id));

            if (model != null)
                return View(model);
            else
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(PublisherModel model)
        {
            if (_publisherRepository.Save(PublisherModel.Convert(model), out string StatusCode))
            {
                if (StatusCode == "U001")
                {
                    Notify("Update", "Record Updated Successfully!", NotificationType.success);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Notify("Error", "system not able to process this request!", NotificationType.error);

                }
            }
            return View(model);
        }

    }
}