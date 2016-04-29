namespace Restorant.Web.Controllers
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    public class UploadResumeController : Controller
    {
        // GET: UploadResume
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase file)
        {

            int iFileSize = file.ContentLength;

            if (iFileSize > 1 * 1024 * 1024)  // 1MB
            {
                ViewBag.fileSize = "File to Big, Please Select file with size up to 1MB";
                return View();
            }
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = b.ReadBytes((int)file.InputStream.Length);
            //var currentUser = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            var currentFileName = file.FileName;
            var currentDirectory = String.Format("~/UploadedResumes/{0}",currentFileName);
            string filePath = Server.MapPath(Url.Content(currentDirectory));
            System.IO.File.WriteAllBytes(filePath, binData);
            this.TempData["Notification"] = "Your application has been sent successfully, we will be in touch within 24 hours.";

            //System.Web.HttpException: Maximum request length exceeded
            return Redirect("/");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Download()
        {
            var currentDirectory = "~/App_Data/kitty.jpg";
            return this.File(currentDirectory, "application/octet-stream","Form.jpg");
        }
    }
}