namespace Restorant.Data.Models
{
    using Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;


    public class CommentForm: AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
