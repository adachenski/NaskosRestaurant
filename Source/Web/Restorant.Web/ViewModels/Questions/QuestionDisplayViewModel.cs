namespace Restorant.Web.ViewModels.Questions
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class QuestionDisplayViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}