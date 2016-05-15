namespace Restorant.Web.Controllers
{
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Jokes;
    public class JokeController : Controller
    {
        private IDeletableEntityRepository<Joke> jokes;

        public JokeController(IDeletableEntityRepository<Joke>j)
        {
            this.jokes = j;
        }
       

        // GET: Joke
        [HttpGet]
        [ChildActionOnly]
        public ActionResult _JokePartial()
        {
             var jokes = this.jokes.All().OrderBy(x => Guid.NewGuid())
                .Take(3).Select(x=>new JokeViewModel() {Content= x.Content })
                .ToList();

            return PartialView(jokes);
        }
    }
}