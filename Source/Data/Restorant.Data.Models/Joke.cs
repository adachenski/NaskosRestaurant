using System;
using Restorant.Data.Common.Models;

namespace Restorant.Data.Models
{
    public class Joke : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual JokeCategory Category { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; } 
    }
}
