using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewDemo.Models
{
    public class SearchModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Search String is required")]
        public string SearchName { set; get; }
    }
}