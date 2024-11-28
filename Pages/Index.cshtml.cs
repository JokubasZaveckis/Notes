using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Models;

namespace Notes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Note> Notes { get; set; } = new List<Note>();

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Notes = _context.Notes.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.ID == id);

            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToPage("/Index"); // Reload the main page
        }
    }
}
