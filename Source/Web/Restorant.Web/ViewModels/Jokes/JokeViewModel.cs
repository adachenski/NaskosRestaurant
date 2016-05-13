namespace Restorant.Web.ViewModels.Jokes
{
    using AutoMapper;
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;

    public class JokeViewModel: IMapFrom<Joke>
    {
        public string Content { get; set; }

        public string Category { get; set; }

    }
}