namespace Marketplace.Models
{
    public class PhoneViewModel
    {
        public PaginatedList<Phone> Phones { get; set; }
        public IEnumerable<Store> Stores { get; set; }
    }
}
