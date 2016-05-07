namespace Restorant.Data.Models
{
    using Restorant.Data.Common.Models;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Address : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [DisplayName("Street Address")]
        public string StreetAdress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("ZipCode")]
        public int ZipCode { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
