namespace Restorant.Web.ViewModels.Jokes
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel: IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}