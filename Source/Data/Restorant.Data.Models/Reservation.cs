namespace Restorant.Data.Models
{
    using System;
    using Restorant.Data.Common.Models;

    public class Reservation : AuditInfo, IDeletableEntity
    {
        public Reservation()
        {
        }

        public int Id { get; set; }

        public virtual ApplicationUser Person { get; set; }

        public string PersonId { get; set; }

        public Table Table { get; set; }

        public Post AskSomething { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime ReservedFor { get; set; }
    }
}
