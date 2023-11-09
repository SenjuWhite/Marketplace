using Marketplace.Data;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    public class PhoneController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PhoneController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 20;
            PhoneViewModel model = new PhoneViewModel();
            model.Phones = PaginatedList<Phone>.Create(_db.PhoneInfo.ToList(), pageNumber ?? 1, pageSize);
            model.Stores = _db.StoreInfo;
            return View(model);
        }
    }
}
