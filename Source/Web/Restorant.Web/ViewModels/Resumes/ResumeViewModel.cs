namespace Restorant.Web.ViewModels.Resumes
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ResumeViewModel :IMapFrom<Resume>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string SSN { get; set; }

        public Address Address { get; set; }

        public Address SecondAddress { get; set; }

        public string ApplyForPosition { get; set; }

        public int DesiredSalary { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}