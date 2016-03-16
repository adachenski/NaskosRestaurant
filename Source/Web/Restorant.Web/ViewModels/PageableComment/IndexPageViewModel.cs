namespace Restorant.Web.ViewModels.PageableComment
{
    using System.Collections.Generic;

    public class IndexPageViewModel
    {
        public Pager Pager { get; set; }

        public IEnumerable<PageableComment> AllComments { get; set; }

        public string SorthValues { get; set; }

        public int PageSize { get; set; }
    }
}