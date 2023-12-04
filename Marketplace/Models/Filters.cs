namespace Marketplace.Models
{
    public class Filters
    {
        public List<string?>? Memory {get;set;}
        public List<string?> RAM { get; set; }
        public List<string?> Refresh_Rate { get; set; }
        public List<string?> Brand { get; set; }
        public Filters()
        {
            Memory = new List<string?>();
            RAM = new List<string?>();
            Refresh_Rate = new List<string?>();
            Brand = new List<string?>();
        }
    }
}
