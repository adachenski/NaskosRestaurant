using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Restorant.Web.ViewModels.CommentForm
{
    using System.Web.Mvc;

    public class CommentFormViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}