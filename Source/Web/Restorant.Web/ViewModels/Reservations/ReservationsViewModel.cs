namespace Restorant.Web.ViewModels.Reservations
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReservationsViewModel: IMapFrom<Reservation>
    {
        public Table Table { get; set; }

        [Display(Name = "Ask Question")]
        public Post AskSomething { get; set; }

        [Required]
        public DateTime ReservedFor { get; set; }

    }
}