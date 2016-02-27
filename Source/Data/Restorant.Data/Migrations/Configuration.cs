namespace Restorant.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Comments.Any())
            {
                for (int i = 0; i < 18; i++)
                {
                    var currentComment = new CommentForm
                    {
                        Title = $"Comment{i}",
                        Description = $"Automaticly Generated Description Lorem ipsum dolor color {i}",
                    };
                    context.Comments.Add(currentComment);
                }
                context.SaveChanges();
            }
        }
    }
}
