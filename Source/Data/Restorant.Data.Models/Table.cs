using Restorant.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Data.Models
{
    public class Table : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public int NumberOfChairs { get; set; }

        [Required]
        [Display(Name = "Choose this Table")]
        public bool IsTaken { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
