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
            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = b.ReadBytes((int)file.InputStream.Length);
            //var currentUser = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            var currentFileName = file.FileName;
            var currentDirectory = String.Format("~/UploadedResumes/{0}",currentFileName);
            string filePath = Server.MapPath(Url.Content(currentDirectory));
            System.IO.File.WriteAllBytes(filePath, binData);
            this.TempData["Notification"] = "Your application has been sent successfully, we will be in touch within 24 hours.";

            try
            {
            }
            catch (Exception ex)
            { return View("Error"); }
            //System.Web.HttpException: Maximum request length exceeded
            return Redirect("/");
        }
    }
}