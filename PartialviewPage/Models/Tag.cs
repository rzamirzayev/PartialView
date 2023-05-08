using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PartialviewPage.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public List<BookTag> BookTags { get; set; }
    }
}
