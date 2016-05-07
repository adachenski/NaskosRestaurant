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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ApplyForPosition { get; set; }

        public string DesiredSalary { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string SSN { get; set; }

        public Address Address { get; set; }

        public Address SecondAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
