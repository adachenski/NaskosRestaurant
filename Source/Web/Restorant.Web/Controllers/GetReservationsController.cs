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

    public class GetReservationsController : Controller
    {
        IDeletableEntityRepository<Reservation> reservations;

        public GetReservationsController(DeletableEntityRepository<Reservation> reservations)
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
        public ActionResult Delete (int ? id)
        {
           //need to fix delete action
            var postViewModel = this.reservations.All().Where(x => x.Id == id)
               .Project().To<Reservation>().FirstOrDefault();
            reservations.Delete(postViewModel);
            Mapper.CreateMap<Reservation, Reservation>();
            reservations.SaveChanges();
            return Redirect("/GetReservations/IndexReservations");
        }
    }
}