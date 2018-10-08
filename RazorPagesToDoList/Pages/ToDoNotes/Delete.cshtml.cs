using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesToDoList.Models;

namespace RazorPagesToDoList.Pages.ToDoNotes
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesToDoList.Models.RazorPagesToDoListContext _context;

        public DeleteModel(RazorPagesToDoList.Models.RazorPagesToDoListContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoNote = await _context.ToDoNote.FindAsync(id);

            if (ToDoNote != null)
            {
                _context.ToDoNote.Remove(ToDoNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
