using DefenseSim.Data.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefenseSim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIattackController : ControllerBase
    {
        private readonly IAttackService _service;
        public APIattackController(IAttackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<string[]> GetLocationOptions()
        {
            return _service.GetLocationsName();
        }
    }
}
