using DefenseSim.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefenseSim.Controllers
{
    public class AttackController : Controller
    {
        private readonly AppDbContext _context;
        public AttackController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
