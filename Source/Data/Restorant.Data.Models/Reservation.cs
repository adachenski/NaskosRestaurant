namespace Restorant.Data.Models
{
    using Restorant.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Reservation : AuditInfo, IDeletableEntity
    {
        public Reservation()
        {
            this.Comments = new CommentForm();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Person { get; set; }

        public string PersonId { get; set; }

        public Table Table { get; set; }

        public virtual CommentForm Comments { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public DateTime ReservedFor { get; set; }
    }
}
