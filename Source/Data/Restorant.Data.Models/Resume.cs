namespace Restorant.Data.Models
{
    using System;
    using Restorant.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    public class Resume : AuditInfo, IDeletableEntity
    {
        public Resume()
        {

        }
        public int Id { get; set; }

        public virtual ApplicationUser Person { get; set; }

        public string PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ApplyForPosition { get; set; }

        public int DesiredSalary { get; set; }

        [Required]
        public string SSN { get; set; }

        public Address Address { get; set; }

        public Address SecondAddress { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
