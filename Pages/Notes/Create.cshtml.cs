using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Models;

namespace Notes.Pages.Notes
{
    public class CreateModel: PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Note Note {get; set;} = new Note();

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            _context.Notes.Add(Note);
            _context.SaveChanges();

            return Redirect("/");
        }
    }
}