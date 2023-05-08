using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartialviewPage.Models;
namespace PartialviewPage.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Feature> Features { get; set; }

        public DbSet<Slider> Sliders { get; set; }


        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<BookTag> BookTags { get; set; }
    }
}
