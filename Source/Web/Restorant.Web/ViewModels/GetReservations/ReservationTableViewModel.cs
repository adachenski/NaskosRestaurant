namespace Restorant.Web.ViewModels.GetReservations
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;

    public class ReservationTableViewModel : IMapFrom<Table>
    {
        public int NumberOfChairs { get; set; }
    }
}