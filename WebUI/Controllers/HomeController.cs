using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agency.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Portfolios);
        }
    }
}