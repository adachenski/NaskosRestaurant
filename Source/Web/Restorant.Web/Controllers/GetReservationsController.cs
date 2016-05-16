namespace Restorant.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Restorant.Data.Common.Repository;
    using Restorant.Data.Models;
    using Restorant.Web.ViewModels.GetReservations;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using Infrastructure.Mapping;
    public class GetReservationsController : Controller
    {
        GenericRepository<Reservation> reservations;

        public GetReservationsController(GenericRepository<Reservation> reservations)
        {
            this.reservations = reservations;
        }
        // GET: GetReservations
        [HttpGet]
        [Authorize]
        public ActionResult IndexReservations()
        {
            var currentUser = User.Identity.GetUserId();

            var allReservations = this.reservations.All().Where(p => p.PersonId == currentUser)
                .Project().To<GetReservationsVIewModel>();

            // var dbPerson = from p in allReservations
            //                where p.PersonId == currentUser
            //                orderby p.ReservedFor descending
            //                select p;

            // if (!allReservations.Any())
            // {
            //     ViewBag.getReservations = "No reservation yet!";
            //     return this.View();
            // }

            return this.View(allReservations);
        }

        [HttpGet]
        public ActionResult Delete(int? id, int page = 1)
        {
            var postViewModel = this.reservations.All().Where(x => x.Id == id)
                .Project().To<GetReservationsVIewModel>().FirstOrDefault();

            if (postViewModel == null)
            {
                return this.HttpNotFound("No such post");
            }

            return this.View(postViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var postViewModel = this.reservations.All()
                .Where(x => x.Id == id)
               .FirstOrDefault();
            this.reservations.Delete(postViewModel);
            this.reservations.SaveChanges();
            return Redirect("/GetReservations/IndexReservations");
        }
    }
}