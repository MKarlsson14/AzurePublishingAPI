using AzurePublishingAPI.Data;
using AzurePublishingAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzurePublishingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepository<Item> itemRepo;

        public ItemController(IRepository<Item> itemRepo)
        {
            this.itemRepo = itemRepo;
        }

        [HttpGet("health")] 
        public IActionResult HealthCheck()
        {          

            return Ok("API is running"); 
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await itemRepo.GetAllAsync();

            if(items.Count() > 0)
            {
                return Ok(items);
            }
            else
            {
                return NotFound("No content found");
            }
        }
  
    }
}
