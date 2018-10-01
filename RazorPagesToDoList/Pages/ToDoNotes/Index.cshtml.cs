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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesToDoList.Models.RazorPagesToDoListContext _context;

        public IndexModel(RazorPagesToDoList.Models.RazorPagesToDoListContext context)
        {
            _context = context;
        }

        public IList<ToDoNote> ToDoNote { get;set; }

        public async Task OnGetAsync()
        {
            ToDoNote = await _context.ToDoNote.ToListAsync();
        }
    }
}
