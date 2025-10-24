using Microsoft.AspNetCore.Mvc;
using DatadogCrud.Api.Data;
using DatadogCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _db;
    public ItemsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _db.Items.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _db.Items.FindAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Item input)
    {
        var item = await _db.Items.FindAsync(id);
        if (item == null) return NotFound();
        item.Name = input.Name;
        item.Description = input.Description;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.Items.FindAsync(id);
        if (item == null) return NotFound();
        _db.Items.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}