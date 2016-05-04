namespace Restorant.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ViewModels.Home;
    using Data.Common.Repository;
    using Data.Models;
    using System;
    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;

        public HomeController(IDeletableEntityRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            //var model = this.posts.All().Project().To<IndexBlogPostViewModel>();
            return this.View();
        }
    }
}