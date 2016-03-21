namespace Restorant.Web.ViewModels.GetReservations
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;
    using System;

    public class GetReservationsVIewModel: IMapFrom<Reservation>
    {
        public string PersonId { get; set; }

        public ReservationTableViewModel Table { get; set; }

        public ReservationPostViewModel AskSomething { get; set; }

        public DateTime ReservedFor { get; set; }

    }
}