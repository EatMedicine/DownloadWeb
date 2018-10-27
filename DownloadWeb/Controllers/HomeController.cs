using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DownloadWeb.Controllers
{
    public class HomeController : Controller
    {
        private static string path = @"C:\WebDownload\";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Download()
        {
            string path = @"C:\WebDownload\";
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                List<string> filename = new List<string>();
                foreach (FileInfo fi in info.GetFiles())
                {
                    filename.Add(fi.FullName);
                }
                ViewBag.FileName = filename.ToArray();
            }
            catch
            {
                
            }
            return View();
        }

        public FileStreamResult fileDownload(int id)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            List<string> filename = new List<string>();
            foreach (FileInfo fi in info.GetFiles())
            {
                filename.Add(fi.FullName);
            }
            for (int count = 0; count < filename.Count; count++)
            {
                if (count == id) 
                {
                    string fullname = info.GetFiles()[count].FullName;
                    FileStream fs = new FileStream(fullname, FileMode.Open);
                    return File(fs, "application/octet-stream", filename[count]);
                }
            }
            return null;

        }
    }
}