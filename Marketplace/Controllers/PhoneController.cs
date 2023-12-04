using Marketplace.Data;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Marketplace.Controllers
{
    public class PhoneController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PhoneController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult SearchResults( string query, int? pageNumber)
        {
            PhoneViewModel model = new PhoneViewModel();
            int pageSize = 20;
            var phones = _db.PhoneInfo.AsQueryable();
            model.Stores = _db.StoreInfo;
            var filteredPhones = phones.Where(phone => phone.Model.Contains(query)).ToList();
            model.Phones = PaginatedList<Phone>.Create(filteredPhones, pageNumber ?? 1, 20);
            model.selectedQuery = query;
            return View(model);
        }
        public IActionResult Index(int? pageNumber, string[] mem, string[] brand, string[] refreshRate, string[] RAM, int minPrice, int maxPrice)
        {
            PhoneViewModel model = new PhoneViewModel();
            var filteredPhones = _db.PhoneInfo.AsQueryable();
            model.Stores = _db.StoreInfo;
            if (maxPrice != 0)
            {
                minPrice = int.Min(minPrice, maxPrice);
                maxPrice = int.Max(maxPrice, minPrice);
                var IDs = model.Stores.Where(s => int.Parse(s.Price) >= minPrice && int.Parse(s.Price) <= maxPrice).Select(s => s.PhoneId).Distinct();
                filteredPhones = filteredPhones.Where(phone => IDs.Contains(phone.Id));
            }
            if (!brand.IsNullOrEmpty())
            {
                brand = brand[0].Contains(",") ? brand[0].Split(",") : brand;
                filteredPhones = filteredPhones.Where(phone => brand.Contains(phone.Brand));
            }
            if (!refreshRate.IsNullOrEmpty())
            {
                refreshRate = refreshRate[0].Contains(",") ? refreshRate[0].Split(",") : refreshRate;
                filteredPhones = filteredPhones.Where(phone => refreshRate.Contains(phone.Refresh_Rate));
            }
            if (!RAM.IsNullOrEmpty())
            {
                RAM = RAM[0].Contains(",") ? RAM[0].Split(",") : RAM;
                filteredPhones = filteredPhones.Where(phone => RAM.Contains(phone.RAM));
            }
            if (!mem.IsNullOrEmpty())
            {
                mem = mem[0].Contains(",") ? mem[0].Split(",") : mem;    
                filteredPhones = filteredPhones.Where(phone => mem.Contains(phone.Memory));
            }
            int pageSize = 20;

            double result;
            model.Filters.Memory = _db.PhoneInfo.Select(phone => phone.Memory).Where(memory => memory != "unknown").Distinct().ToList();
            model.Filters.Brand = _db.PhoneInfo.Select(phone => phone.Brand).Where(brand => brand != "unknown").Distinct().ToList();
            model.Filters.Refresh_Rate = _db.PhoneInfo.Select(phone => phone.Refresh_Rate).Where(refreshRate => refreshRate != "unknown").Distinct().ToList();
            model.Filters.RAM = _db.PhoneInfo.Select(phone => phone.RAM).Where(RAM => RAM != "unknown" && !RAM.Contains(".")).Distinct().ToList();
            model.SelectedRefreshRate = refreshRate;
            model.SelectedRAM = RAM;
            model.SelectedMemory = mem;
            model.SelectedBrand = brand;
            model.SelectedMaxPrice = int.Max(minPrice, maxPrice);
            model.SelectedMinPrice = int.Min(minPrice, maxPrice);
            model.Phones = PaginatedList<Phone>.Create(filteredPhones.ToList(), pageNumber ?? 1, pageSize);
            
            return View(model);
        }
    }
}
