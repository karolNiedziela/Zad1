using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.API.Data;
using Project.API.Models;
using Project.API.Services;
using StackExchange.Redis;

namespace Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly MSSQLDbContext _context;
        private readonly ICacheService _cacheService;

        public HomeController(MSSQLDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("sql")]
        public async Task<IActionResult> GetFromSql()
        {
            var coefficients = await _context.IntroducedCoefficients.ToListAsync();

            return Ok(coefficients);
        }

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetFromRedis()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            using var redis = ConnectionMultiplexer.Connect("redis:6379,allowAdmin=true");
            var keys = redis.GetServer("redis", 6379).Keys();
            string[] keysArr = keys.Select(key => (string)key).ToArray();

            foreach (var key in keysArr)
            {
                values.Add(key, await _cacheService.Get<string>(key));
            }

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IndexCommand command)
        {
            var result = CalculateFibonnaci(command.Value);

            await _context.IntroducedCoefficients.AddAsync(new IntroducedCoefficient
            {
                Value = result
            });
            await _context.SaveChangesAsync();

            await _cacheService.Set<string>(command.Value.ToString(), result.ToString());

            return Ok();
        }

        private int CalculateFibonnaci(int value)
        {
            if (value == 1 || value == 2)
            {
                return 1;
            }
            else
            {
                return CalculateFibonnaci(value - 1) + CalculateFibonnaci(value - 2);
            }
        }
    }
}
