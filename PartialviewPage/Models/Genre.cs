using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PartialviewPage.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

    }
}
