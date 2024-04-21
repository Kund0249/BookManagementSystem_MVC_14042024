using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookManagementSystem_MVC_14042024.Controllers
{
    public enum NotificationType
    {
        success,warrning,error,info
    }
    public class BaseController : Controller
    {
       public void Notify(string Title,string Message, NotificationType MessageType)
        {
            var messagetype = string.Empty;
            switch (MessageType)
            {
                case NotificationType.success:
                    messagetype = "success";
                    break;
                case NotificationType.warrning:
                    messagetype = "warrning";
                    break;
                case NotificationType.error:
                    messagetype = "error";
                    break;
                case NotificationType.info:
                    messagetype = "info";
                    break;
                default:
                    break;
            }
            var data = new
            {
                Title = Title,
                Message = Message,
                Type = messagetype
            };

            var Js = new JavaScriptSerializer();
            var MessageData = Js.Serialize(data);
            TempData["Message"] = MessageData;
        }
    }
}