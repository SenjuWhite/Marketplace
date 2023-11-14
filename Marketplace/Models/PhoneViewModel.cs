namespace Marketplace.Models
{
    public class PhoneViewModel
    {
        public PaginatedList<Phone> Phones { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public string[] SelectedMemory { get; set; }
        public Filters Filters { get; set; }
        public PhoneViewModel()
        {
            Filters = new Filters();
        }
    }
}
