namespace Restorant.Web.ViewModels.Resumes
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class AddressViewModel:IMapFrom<Address>
    {
        [Required]
        [DisplayName("Street Address")]
        public string StreetAdress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public int? ZipCode { get; set; }
    }
}