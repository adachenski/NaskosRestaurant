namespace Restorant.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Restorant.Data.Common.Repository;
    using Restorant.Data.Models;
    using Restorant.Web.ViewModels.Reservations;
    using System.Web.Mvc;

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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationsViewModel userReservation)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var newReservation = new Reservation
                {
                    PersonId = this.User.Identity.GetUserId(),
                    Table = userReservation.Table,
                    ReservedFor = userReservation.ReservedFor,
                    AskSomething = userReservation.AskSomething
                    
                };

                this.reservations.Add(newReservation);
                this.reservations.SaveChanges();
                this.TempData["Notification"] = "Your reservation has been Approved";
            }
            return Redirect("/");
        }
    }
}