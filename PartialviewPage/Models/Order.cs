
using System.ComponentModel.DataAnnotations;

namespace PartialviewPage.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string AppUserId { get; set; }
		[MaxLength(25)]
		public string FullName { get; set; }
		[MaxLength(25)]
		public string Phone { get; set; }
		[MaxLength(250)]
		public string Address { get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
		[MaxLength(500)]
		public string Note { get; set; }
		public DateTime CreatedAt { get; set; }

		public AppUser AppUser { get; set; }
		public List<OrderItem> OrderItems { get; set;} = new List<OrderItem>();
	}
}
