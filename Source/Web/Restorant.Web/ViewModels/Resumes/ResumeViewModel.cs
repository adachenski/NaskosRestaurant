namespace Restorant.Web.ViewModels.Resumes
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ResumeViewModel :IMapFrom<Resume>
    {
        [Required]
        [DisplayName("First Name ")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name ")]
        public string LastName { get; set; }

        [Required]
        public string SSN { get; set; }

        public Address Address { get; set; }

        [DisplayName("Secondary Address")]
        public Address SecondAddress { get; set; }

        [DisplayName("Position Applied For")]
        public string ApplyForPosition { get; set; }

        [DisplayName("Desired Salary")]
        public int DesiredSalary { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}