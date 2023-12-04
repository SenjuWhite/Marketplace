namespace Marketplace.Models
{
    public class PhoneViewModel
    {
        public PaginatedList<Phone> Phones { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public string[] SelectedMemory { get; set; }
        public string[] SelectedBrand { get; set; }
        public string[] SelectedRAM { get; set; }
        public string[] SelectedRefreshRate { get; set; }
        public int SelectedMaxPrice { get; set; }
        public int SelectedMinPrice { get; set; }  
        public string selectedQuery { get; set; }
        public Filters Filters { get; set; }
        public PhoneViewModel()
        {
            Filters = new Filters();
        }
    }
}
