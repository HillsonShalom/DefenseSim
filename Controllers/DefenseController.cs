using DefenseSim.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefenseSim.Controllers
{
    public class DefenseController : Controller
    {
        private readonly AttackDbContext _context;
        public DefenseController(AttackDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
