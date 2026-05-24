using BlazorApp2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazerApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public InventoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _db.Inventoryitems.ToListAsync();
            return Ok(items);
        }

        // GET: api/Inventory/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _db.Inventoryitems.FindAsync(id);

            if (item == null)
                return NotFound($"Item with ID {id} not found.");

            return Ok(item);
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Inventoryitems item)
        {
            if (item == null)
                return BadRequest();

            await _db.Inventoryitems.AddAsync(item);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/Inventory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Inventoryitems updatedItem)
        {
            if (id != updatedItem.Id)
                return BadRequest("ID mismatch");

            var existingItem = await _db.Inventoryitems.FindAsync(id);

            if (existingItem == null)
                return NotFound();

            // Update fields (change these based on your model)
            existingItem.ItemName = updatedItem.ItemName;
            existingItem.Quantity = updatedItem.Quantity;
            existingItem.Price = updatedItem.Price;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Inventory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Inventoryitems.FindAsync(id);

            if (item == null)
                return NotFound();

            _db.Inventoryitems.Remove(item);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // Helper
        private bool ItemExists(int id)
        {
            return _db.Inventoryitems.Any(e => e.Id == id);
        }
    }
}