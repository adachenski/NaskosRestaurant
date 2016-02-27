using Microsoft.AspNet.Identity;
using Restorant.Data.Common.Repository;
using Restorant.Data.Models;
using Restorant.Web.ViewModels.CommentForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restorant.Web.Controllers
{
    public class CommentFormController : Controller
    {
        // GET: CommentForm
        IDeletableEntityRepository<CommentForm> feedbacks;

        public CommentFormController(IDeletableEntityRepository<CommentForm> feedBacks)
        {
            this.feedbacks = feedBacks;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentFormViewModel comment)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var newComment = new CommentForm
                {
                    Title = comment.Title,
                    Description = comment.Description,
                    AuthorId = this.User.Identity.GetUserId()
                };
                this.feedbacks.Add(newComment);
                this.feedbacks.SaveChanges();
                this.TempData["Notification"] = "Thank you for your Feedback";
            }
            else
            {
                this.TempData["Notification"] = "You must be logged in to live a comment";
            }


            return this.Redirect("Create");
        }
    }
}