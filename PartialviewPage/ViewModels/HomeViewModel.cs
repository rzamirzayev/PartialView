using Microsoft.AspNetCore.Mvc;
using PartialviewPage.Models;

namespace PartialviewPage.ViewModels
{
    public class HomeViewModel
    {
        public List<Feature> Features = new List<Feature>();


        public List<Book> FeaturedBooks = new List<Book>();

        public List<Slider> Sliders = new List<Slider>();
        public List<Book> NewBooks = new List<Book>();

        public List<Book> DiscountedBooks = new List<Book>();

    }
}
