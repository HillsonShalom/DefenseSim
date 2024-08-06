using DefenseSim.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefenseSim.Controllers
{
    public class DefenseController : Controller
    {
        private readonly AppDbContext _context;
        public DefenseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
