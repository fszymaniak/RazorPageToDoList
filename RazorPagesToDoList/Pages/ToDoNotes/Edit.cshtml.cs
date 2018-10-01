using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesToDoList.Models;

namespace RazorPagesToDoList.Pages.ToDoNotes
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesToDoList.Models.RazorPagesToDoListContext _context;

        public EditModel(RazorPagesToDoList.Models.RazorPagesToDoListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoNote ToDoNote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoNote = await _context.ToDoNote.FirstOrDefaultAsync(m => m.Id == id);

            if (ToDoNote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoNoteExists(ToDoNote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoNoteExists(int id)
        {
            return _context.ToDoNote.Any(e => e.Id == id);
        }
    }
}
