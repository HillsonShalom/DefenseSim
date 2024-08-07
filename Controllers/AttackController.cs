using DefenseSim.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefenseSim.Controllers
{
    public class AttackController : Controller
    {
        private readonly AttackDbContext _context;
        public AttackController(AttackDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
