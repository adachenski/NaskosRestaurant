namespace Restorant.Data.Models
{
    using Restorant.Data.Common.Models;
    using System;
    using System.ComponentModel;
    public class Address : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [DisplayName("Street Address")]
        public string StreetAdress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
