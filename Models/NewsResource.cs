using System;
using System.ComponentModel.DataAnnotations;

namespace power_classroom.Models
{
    public enum ArticleEnum {
        News = 0,
        Resource = 1
    }
    public class NewsResource
    {
        public Guid Id { get; set; }

        [Required]
        public ArticleEnum ArticleType { get; set;}

        [Required]
        public string Title { get; set; }

        public string Source { get; set; }

        [Required]
        public string URL { get; set; }
    }
}