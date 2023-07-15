using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BoostNotes.Data.Contexts;
using BoostNotes.Domain.Entities;

namespace BoostNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly ILogger<NoteController> _logger;
    private readonly BoostNotesDbContext _context;
    
    public NoteController(
        ILogger<NoteController> logger,
        BoostNotesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Notes);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Note note)
    {
        await _context.Notes.AddAsync(note);
        await _context.SaveChangesAsync();

        return Ok(note);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] long id, [FromBody] Note note)
    {
        _context.Update(note);

        await _context.SaveChangesAsync();

        return Ok(note);
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var note = await _context.Notes.SingleOrDefaultAsync(x => x.Id == id);

        if (note == null)
        {
            return NotFound();
        }

        _context.Notes.Remove(note);

        await _context.SaveChangesAsync();

        return Ok(note);
    }
}
