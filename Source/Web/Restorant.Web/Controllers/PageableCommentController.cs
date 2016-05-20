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
        [ChildActionOnly]
        public ActionResult _Index(string SorthByDate, int pageSize=4, int page = 1)
        {
            var dummyItems = this.feedbacks.All();

            if (SorthByDate == "oldest")
            {
                dummyItems = this.feedbacks.All()
                  .OrderBy(x => x.CreatedOn).ThenBy(x => x.Id);
            }
            else
            {
                dummyItems = this.feedbacks.All()
                                .OrderByDescending(x => x.CreatedOn).ThenBy(x => x.Id);
            }
            var pager = new Pager(dummyItems.Count(),SorthByDate, page, pageSize);

            var viewModel = new IndexPageViewModel
            {
                AllComments = dummyItems
                .Skip((pager.CurrentPage - 1) * pager.PageSize)
                .Take(pager.PageSize)
                .Project()
                .To<PageableComment>()
                .ToList(),
                Pager = pager,
                SorthValues  = pager.CurrentSorth,
                PageSize = pager.PageSize
            };

            return PartialView(viewModel);
        }
    }
}