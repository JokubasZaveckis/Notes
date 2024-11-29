using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Models;

namespace Notes.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Note? Note { get; set; } = new Note();

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        // Load the note to edit
        public IActionResult OnGet(int id)
        {
            Note = _context.Notes.FirstOrDefault(n => n.ID == id);

            if (Note == null)
            {
                return NotFound();
            }

            return Page();
        }

            // Save the changes
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid || Note == null)
        {
            return Page();
        }

        var noteInDb = _context.Notes.FirstOrDefault(n => n.ID == Note.ID);
        if (noteInDb == null)
        {
            return NotFound();
        }

        // Update note properties
        noteInDb.Title = Note.Title;
        noteInDb.Content = Note.Content;
        noteInDb.Category = Note.Category;
        noteInDb.CreatedAt = Note.CreatedAt;

        _context.SaveChanges();
        return RedirectToPage("/Index");
    }

    }
}
