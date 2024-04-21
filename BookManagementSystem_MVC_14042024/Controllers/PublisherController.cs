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
        public ViewResult Index()
        {
            //List<PublisherModel> models = _publisherRepository.
            //                               GetPublishers.
            //                               Select(x => new PublisherModel()
            //                               {
            //                                   PublisherId = x.PublisherId,
            //                                   PublisherName = x.PublisherName,
            //                                   RegistrationId = x.RegistrationId
            //                               }).ToList();
            List<PublisherModel> models = _publisherRepository.
                                           GetPublishers.
                                           Select(x => PublisherModel.Convert(x)).ToList();
            return View(models);
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