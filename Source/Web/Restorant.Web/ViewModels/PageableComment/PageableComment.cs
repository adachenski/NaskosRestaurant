using Restorant.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Restorant.Web.ViewModels.PageableComment
{
    public class PageableComment:IMapFrom<Restorant.Data.Models.CommentForm>,IHaveCustomMappings
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //public string SanitizedContent => this.sanitizer.Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Restorant.Data.Models.CommentForm, PageableComment>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}