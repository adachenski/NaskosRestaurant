using AutoMapper.QueryableExtensions;
using Restorant.Data.Common.Repository;
using Restorant.Data.Models;
using Restorant.Web.ViewModels.PageableComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restorant.Web.Controllers
{
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
        public ActionResult Index(int id =1)
        {
            PageableCommentViewModel pageableCommentViewModel;
            if (this.HttpContext.Cache["Comment_page_id"+id]!=null)
            {
                pageableCommentViewModel = (PageableCommentViewModel)this.HttpContext.Cache["Comment_page_id" + id];
            }
            else
            {
                var page = id;
                var allItemsCount = this.feedbacks.All().Count();
                var totalPages =allItemsCount / itemPerPage;
                var itemToSkip = (page - 1) * itemPerPage;
                var pageableComments = this.feedbacks.All()
                    .OrderBy(x => x.CreatedOn).ThenBy(x => x.Id)
                    .Skip(itemToSkip).Take(itemPerPage).Project().To<PageableComment>().ToList();

                pageableCommentViewModel = new PageableCommentViewModel
                {
                    TotalPages = totalPages,
                    CurrentPage = page,
                    AllComments = pageableComments
                };
            }
            return PartialView(pageableCommentViewModel);
        }
    }
}