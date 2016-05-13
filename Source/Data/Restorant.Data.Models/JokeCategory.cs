namespace Restorant.Data.Models
{
    using System;
    using Restorant.Data.Common.Models;
    using System.Collections.Generic;
    public class JokeCategory : AuditInfo, IDeletableEntity
    {
        public JokeCategory()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get;  set; }
    }
}