using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restorant.Web.ViewModels.PageableComment
{
    public class PageableCommentViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<PageableComment> AllComments { get; set; }
    }
}