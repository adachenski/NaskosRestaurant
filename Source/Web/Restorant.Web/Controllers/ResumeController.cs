namespace Restorant.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Restorant.Data.Common.Repository;
    using Restorant.Data.Models;
    using Restorant.Web.ViewModels.Resumes;
    using System;
    using System.Web.Mvc;

    public class ResumeController : Controller
    {
        IDeletableEntityRepository<Resume> resume;

        public ResumeController(IDeletableEntityRepository<Resume> Resume)
        {
            this.resume = Resume;
        }
        // GET: Resume
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResumeViewModel userResume)
        {
            var newResume = new Resume
            {
               // Person = userResume.Person,
                PersonId = this.User.Identity.GetUserId(),
                FirstName = userResume.FirstName,
                LastName = userResume.LastName,
                ApplyForPosition = userResume.ApplyForPosition,
                DesiredSalary = userResume.DesiredSalary,
                CreatedOn = userResume.CreatedOn,
                Address = userResume.Address,
                PhoneNumber = userResume.PhoneNumber,
                EmailAddress = userResume.EmailAddress,
                SecondAddress = userResume.SecondAddress,
                SSN= userResume.SSN,
                DateOfBirth = userResume.DateOfBirth,
               
            };
            this.resume.Add(newResume);
            this.resume.SaveChanges();
            this.TempData["Notification"] = "Your Application has been Send";

            return Redirect("/");
        }
    }
}