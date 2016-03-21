namespace Restorant.Web.ViewModels.GetReservations
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;

    public class ReservationPostViewModel :IMapFrom<Post>
    {
        public string Content { get; set; }
    }
}