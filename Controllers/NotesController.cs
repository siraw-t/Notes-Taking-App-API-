using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Api.Data;
using Notes.Api.DTOs;
using Notes.Api.Models;
using System.Security.Claims;

namespace Notes.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var notes = await _context.Notes
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NoteDto { Id = n.Id, Title = n.Title, Content = n.Content, CreatedAt = n.CreatedAt})
                .ToListAsync();
            
            return Ok(notes);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteForCreationDto noteForCreationDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var note = new Note
            {
                Title = noteForCreationDto.Title,
                Content = noteForCreationDto.Content,
                UserId = userId
            };

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

             var noteDto = new NoteDto { Id = note.Id, Title = note.Title, Content = note.Content, CreatedAt = note.CreatedAt};

            return CreatedAtAction(nameof(GetNote), new { id = note.Id }, noteDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var note = await _context.Notes
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
            
            if(note == null)
                return NotFound();

            var noteDto = new NoteDto { Id = note.Id, Title = note.Title, Content = note.Content, CreatedAt = note.CreatedAt};

            return Ok(noteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, NoteForUpdateDto noteForUpdateDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

            if (note == null)
                return NotFound();

            note.Title = noteForUpdateDto.Title;
            note.Content = noteForUpdateDto.Content;

            _context.Notes.Update(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);

            if (note == null)
                return NotFound();
            
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}