using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
    }
}
