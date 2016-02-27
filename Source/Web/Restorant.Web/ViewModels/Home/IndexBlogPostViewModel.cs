namespace Restorant.Web.ViewModels.Home
{
    using Restorant.Data.Models;
    using Restorant.Web.Infrastructure.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }
    }
}