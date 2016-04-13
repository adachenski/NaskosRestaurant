namespace Restorant.Data.Models
{
    using Restorant.Data.Common.Models;
    using System;

    public class Address : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string StreetAdress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public byte ZipCode { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
