using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PartialviewPage.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        public List<Author> Authors { get; set; }
        public object Books { get; internal set; }
    }
}
