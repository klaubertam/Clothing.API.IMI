using Clothing.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clothing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothingItemsController : ControllerBase
    {
        private static List<ClothingItem> _items = new List<ClothingItem>
        {
            new ClothingItem { Id = 1, Emri = "Këmishë Klasike Blu", Kategoria = "Këmishë", Madhesia = "M", Cmimi = 2500, Sasia = 15 },
            new ClothingItem { Id = 2, Emri = "Pantallona Jeans", Kategoria = "Pantallona", Madhesia = "L", Cmimi = 3500, Sasia = 10 },
            new ClothingItem { Id = 3, Emri = "Xhaketë Dimri", Kategoria = "Xhaketë", Madhesia = "XL", Cmimi = 7500, Sasia = 5 }
        };

        private static int _nextId = 4;

        // GET: api/clothingitems
        [HttpGet]
        public ActionResult<IEnumerable<ClothingItem>> GetAll()
        {
            return Ok(_items);
        }

        // GET: api/clothingitems/1
        [HttpGet("{id}")]
        public ActionResult<ClothingItem> GetById(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/clothingitems
        [HttpPost]
        public ActionResult<ClothingItem> Create(ClothingItem item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/clothingitems/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, ClothingItem updatedItem)
        {
            var existing = _items.FirstOrDefault(i => i.Id == id);
            if (existing == null) return NotFound();

            existing.Emri = updatedItem.Emri;
            existing.Kategoria = updatedItem.Kategoria;
            existing.Madhesia = updatedItem.Madhesia;
            existing.Cmimi = updatedItem.Cmimi;
            existing.Sasia = updatedItem.Sasia;

            return NoContent();
        }

        // DELETE: api/clothingitems/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            _items.Remove(item);
            return NoContent();
        }
    }
}