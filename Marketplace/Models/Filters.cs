namespace Marketplace.Models
{
    public class Filters
    {
        public List<string?>? Memory {get;set;}
        public List<string?> RAM { get; set; }
        public List<string?> Refresh_Rate { get; set; }
        public List<string?> Size { get; set; }
        public List<string?> MainCamera { get; set; }
        public List<string?> FrontCamera { get; set; }
        public List<string?> Brand { get; set; }
        public Filters()
        {
            Memory = new List<string?>();
            RAM = new List<string?>();
            Refresh_Rate = new List<string?>();
            Size = new List<string?>();
            MainCamera = new List<string?>();
            FrontCamera = new List<string?>();
            Brand = new List<string?>();
        }
    }
}
