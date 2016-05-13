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

        public ResumeController
            (IDeletableEntityRepository<Resume> resume)
        {
            this.resume = resume;
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
            if (ModelState.IsValid)
            {
                var newAddres = new Address
                {
                    StreetAdress = userResume.Address.StreetAdress,
                    City = userResume.Address.City,
                    State = userResume.Address.State,
                    ZipCode = userResume.Address.ZipCode
                };
                var newSecondAddres = new Address
                {
                    StreetAdress = userResume.SecondAddress.StreetAdress,
                    City = userResume.SecondAddress.City,
                    State = userResume.SecondAddress.State,
                    ZipCode = userResume.SecondAddress.ZipCode
                };
                var newResume = new Resume
                {
                    // Person = userResume.Person,
                    PersonId = this.User.Identity.GetUserId(),
                    FirstName = userResume.FirstName,
                    LastName = userResume.LastName,
                    ApplyForPosition = userResume.ApplyForPosition,
                    DesiredSalary = userResume.DesiredSalary,
                    CreatedOn = DateTime.Now,
                    PhoneNumber = userResume.PhoneNumber,
                    EmailAddress = userResume.EmailAddress,
                    SSN = userResume.SSN,
                    DateOfBirth = userResume.DateOfBirth,
                    Address = newAddres,
                    SecondAddress = newSecondAddres,

                };
                this.resume.Add(newResume);
                this.resume.SaveChanges();
                this.TempData["Notification"] = "Step 1: Compleated";
                return Redirect("/UploadResume/Index");
            }
            return View(userResume);
          
        }
    }
}