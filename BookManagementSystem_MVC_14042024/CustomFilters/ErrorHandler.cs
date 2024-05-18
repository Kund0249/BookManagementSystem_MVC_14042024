using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManagementSystem_MVC_14042024.CustomFilters
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public ErrorHandler():base()
        {
           
        }
        public override void OnException(ExceptionContext filterContext)
        {
            LogError(filterContext.Exception);
            base.OnException(filterContext);
        }

        private void LogError(Exception ex)
        {
            string DirectoryPath = @"D:\BookManagement_Logs";
            string FileName = DateTime.Now.ToString("ddMMyyyy") + ".txt";
            string FilePath = Path.Combine(DirectoryPath, FileName);


            StreamWriter writer = new StreamWriter(FilePath,true);
            writer.WriteLine("-------------------{0}----------------\n", DateTime.Now.ToString());
            writer.WriteLine("Exception Type : {0}", ex.GetType());
            writer.WriteLine("Exception Message : {0}", ex.Message);
            writer.WriteLine("Trace : {0}", ex.StackTrace);
            writer.WriteLine("--------------------End------------------\n");
            writer.Close();
        }
    }
}