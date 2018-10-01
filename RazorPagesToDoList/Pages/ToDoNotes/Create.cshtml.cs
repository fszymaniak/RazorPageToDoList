using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesToDoList.Models;

namespace RazorPagesToDoList.Pages.ToDoNotes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesToDoList.Models.RazorPagesToDoListContext _context;

        public CreateModel(RazorPagesToDoList.Models.RazorPagesToDoListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoNote ToDoNote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoNote.Add(ToDoNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}