using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NetPromoter.Web.Models
{
    public class AppRating
    {
        public AppRating() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(1, 10,
            ErrorMessage = "{0} value must be between {1} and {2}")]
        public int Rating { get; set; }

        public DateTime CreatedDate { get; set; }

        [Range(1, 5,
            ErrorMessage = "{0} value must be between {1} and {2}")]
        public int RecommendationRating { get; set; }

        [Required]
        public string Suggestions { get; set; }
    }
}