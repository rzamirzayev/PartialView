using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PartialviewPage.Attributes.ValidationAttributes;

namespace PartialviewPage.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Header { get; set; }
        
        public string HeaderThenbr { get; set; }
        [Required]
        [MaxLength(250)]
        public string Desc { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string SliderImage { get; set; }
        [Required]
        public int Order { get; set; }
        [NotMapped]
        [AllowedExtensions("image/jpeg","image/png")]
        public IFormFile ImageFile { get; set; }
        [Required]
        [MaxLength(100)]
        public string Url { get; set; }
    }
}
