using QuanLyVatPhamAPI.Models.Item;
using QuanLyVatPhamAPI.Repository.ItemRepository;
using QuanLyVatPhamAPI.Service;
using Microsoft.AspNetCore.Mvc;
using QuanLyVatPhamAPI.Filter.ItemFilter;
using QuanLyVatPhamAPI.Filter;
using QuanLyVatPhamAPI.Models;
using Azure;

namespace QuanLyVatPhamAPI.Controllers
{
    [ApiController] // Đánh dấu đây là API controller
    [Route("api/[controller]")] // Đường dẫn cơ sở cho API
    public class ItemController : ControllerBase
    {
        private readonly ItemService _service;

        public ItemController(IService<Item> service)
        {
            _service = (ItemService)service;
            ArgumentNullException.ThrowIfNull(_service);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PagingOptions paging)
        {
            var items = _service.Paging(paging.Page, paging.PerPage); 
            ResponseApi response = ResponseApi.Success(items);
            return Ok(response); 
        }

        // GET: api/item/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(string id)
        {
            var item = await _service.GetAsync(id);
            var response = item == null ? ResponseApi.NotFound(item) : ResponseApi.Success(item);
            return Ok(response); 
        }

        // POST: api/item
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item newItem)
        {
            if(newItem == null)
            {
                return Ok(ResponseApi.BadRequest(null));
            }
            newItem.ID = Guid.NewGuid().ToString();
            await _service.AddAsync(newItem);
            var dto = new { ID = newItem.ID, value = newItem };
            return Ok(ResponseApi.Success(dto));
        }

        // PUT: api/item/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(string id, [FromBody] Item updatedItem)
        {
            if (updatedItem == null || updatedItem.ID != id)
            {
                return BadRequest(); 
            }
            var existingItem = await _service.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound(); 
            }

            _service.Update(updatedItem);
            return NoContent(); 
        }

        // DELETE: api/item/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            var existingItem = await _service.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound(); 
            }

            _service.Delete(id); 
            return NoContent(); 
        }
        [HttpGet("filter_item")]
        public IActionResult Filter([FromQuery] ItemFilter filter)
        {
            var items = _service.Filter(filter);
            return Ok(items);
        }
    }
}
