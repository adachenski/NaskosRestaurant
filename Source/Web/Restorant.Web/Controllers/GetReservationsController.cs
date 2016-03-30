using AutoMapper.QueryableExtensions;
using Restorant.Data.Common.Repository;
using Restorant.Data.Models;
using Restorant.Web.ViewModels.GetReservations;
using Restorant.Web.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Restorant.Web.Controllers
{
    public class GetReservationsController : Controller
    {
        IDeletableEntityRepository<Reservation> reservations;

        public GetReservationsController(IDeletableEntityRepository<Reservation> reservations)
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
    }
}