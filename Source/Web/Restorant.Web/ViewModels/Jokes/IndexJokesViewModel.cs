namespace Restorant.Web.ViewModels.Jokes
{
    using System.Collections.Generic;

    public class IndexJokesViewModel
    {
        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}