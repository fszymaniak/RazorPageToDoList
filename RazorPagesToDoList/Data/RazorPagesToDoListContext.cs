using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesToDoList.Models
{
    public class RazorPagesToDoListContext : DbContext
    {
        public RazorPagesToDoListContext (DbContextOptions<RazorPagesToDoListContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesToDoList.Models.ToDoNote> ToDoNote { get; set; }
    }
}
