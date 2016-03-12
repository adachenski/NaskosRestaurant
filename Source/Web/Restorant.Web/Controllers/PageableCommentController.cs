namespace Restorant.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Restorant.Data.Common.Repository;
    using Restorant.Data.Models;
    using Restorant.Web.ViewModels.PageableComment;
    using System.Linq;
    using System.Web.Mvc;

    public class PageableCommentController : Controller
    {
        const int itemPerPage = 4;
        IDeletableEntityRepository<CommentForm> feedbacks;
        // GET: PageableComment
        public PageableCommentController(IDeletableEntityRepository<CommentForm> feedBacks)
        {
            this.feedbacks = feedBacks;
        }
        [HttpGet]
        public ActionResult _Index( SorthingValues sorthValues , int page = 1 )
        {
            var dummyItems = this.feedbacks.All()
                    .OrderBy(x => x.CreatedOn).ThenBy(x => x.Id);
            if (sorthValues.OrderByDate == "newest")
            {
                dummyItems = this.feedbacks.All()
                    .OrderByDescending(x => x.CreatedOn).ThenBy(x => x.Id);
            }
                                
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new IndexPageViewModel
            {
                AllComments = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).Project().To<PageableComment>().ToList(),
                Pager = pager
            };

            return PartialView(viewModel);
        }
    }
}