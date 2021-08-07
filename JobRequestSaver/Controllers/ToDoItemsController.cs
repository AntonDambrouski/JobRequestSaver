using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AboutFindingJob.Models;

namespace AboutFindingJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoItemsController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GettoDoItems()
        {
            return await _context.toDoItems.Select(x => ItemToDTO(x)).ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetToDoItem(int id)
        {
            var toDoItem = await _context.toDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(toDoItem);
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoItemDTO toDoDTOItem)
        {
            if (id != toDoDTOItem.Id)
            {
                return BadRequest();
            }

            var todoItem = await _context.FindAsync<ToDoItem>(id);
            if (todoItem is null)
            {
                return NotFound();
            }

            todoItem.Name = toDoDTOItem.Name;
            todoItem.IsComleted = toDoDTOItem.IsComleted;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItemDTO toDoItemDTO)
        {
            var todoItem = new ToDoItem
            {
                IsComleted = toDoItemDTO.IsComleted,
                Name = toDoItemDTO.Name
            };

            _context.toDoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoItem), new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var toDoItem = await _context.toDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.toDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoItemExists(int id)
        {
            return _context.toDoItems.Any(e => e.Id == id);
        }

        private static ToDoItemDTO ItemToDTO(ToDoItem todoItem) =>
    new ToDoItemDTO
    {
        Id = todoItem.Id,
        Name = todoItem.Name,
        IsComleted = todoItem.IsComleted
    };
    }
}
