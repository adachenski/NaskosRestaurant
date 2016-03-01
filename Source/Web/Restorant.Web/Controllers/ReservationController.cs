using Microsoft.AspNet.Identity;
using Restorant.Data.Common.Repository;
using Restorant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restorant.Web.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        IDeletableEntityRepository<Reservation> reservations;

        public ReservationController(IDeletableEntityRepository<Reservation> Reservations)
        {
            this.reservations = Reservations;
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation userReservation)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var newReservation = new Reservation
                {
                    PersonId = this.User.Identity.GetUserId(),
                    Table = userReservation.Table,
                    ReservedFor = userReservation.ReservedFor
                    
                };
                if (userReservation.Comments!=null)
                {
                    newReservation.Comments = userReservation.Comments;
                }
                this.reservations.Add(newReservation);
                this.reservations.SaveChanges();
                this.TempData["Notification"] = "Your reservation has been Send";
            }
            return Redirect("/");
        }
    }
}