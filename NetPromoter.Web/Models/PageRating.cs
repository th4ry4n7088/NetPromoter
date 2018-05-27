using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetPromoter.Web.Models
{
    public class PageRating
    {
        public PageRating() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Range(1, 10,
            ErrorMessage = "{0} value must be between {1} and {2}")]
        public int Rating { get; set; }

        [Required]
        public int PageId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}