using PartialviewPage.ViewModels;

namespace PartialviewPage.Areas.Manage.ViewsModels
{
    public class OrderTableViewModels
    {
        public PaginatedList<Order> PaginatedListOrder { get; set; }
        public Order Order { get; set; }
    }
}
