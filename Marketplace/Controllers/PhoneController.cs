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
        
        public IActionResult Index(int? pageNumber, string[] mem)
        {
            var filteredPhones = _db.PhoneInfo.AsQueryable();
            if (!mem.IsNullOrEmpty())
            {
                filteredPhones = filteredPhones.Where(phone => mem.Contains(phone.Memory));
            }
            int pageSize = 20;
            PhoneViewModel model = new PhoneViewModel();
            model.Filters.Memory = _db.PhoneInfo.Select(phone => phone.Memory).Where(memory => memory != "unknown").Distinct().ToList();
            model.SelectedMemory = mem;
            model.Phones = PaginatedList<Phone>.Create(filteredPhones.ToList(), pageNumber ?? 1, pageSize);
            model.Stores = _db.StoreInfo;
            return View(model);
        }
    }
}
