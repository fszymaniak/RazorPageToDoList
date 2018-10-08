using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesToDoList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesToDoListContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesToDoListContext>>()))
            {
                if (context.ToDoNote.Any())
                {
                    return;
                }

                context.ToDoNote.AddRange(
                    new ToDoNote
                    {
                        Title = "DB Project",
                        Priority = "Important not urgent",
                        DueDate = DateTime.Parse("2018-2-12"),
                        TaskDescription = "Project for db subject with Mr. Smith",
                        DutyHolder = "FS",
                        InProgress = true,
                        Done = false 
                    },

                   new ToDoNote
                   {
                       Title = "Pay for books",
                       Priority = "Urgent not important",
                       DueDate = DateTime.Parse("2018-9-30"),
                       TaskDescription = "Pay sis for mine and Kasper's books",
                       DutyHolder = "FS",
                       InProgress = false,
                       Done = true
                   },

                   new ToDoNote
                   {
                       Title = "Buy gift for Grandpa's bday",
                       Priority = "Urgent and important",
                       DueDate = DateTime.Parse("2018-11-5"),
                       TaskDescription = "Talk with sibilngs and decide what we can buy",
                       DutyHolder = "FS",
                       InProgress = true,
                       Done = false
                   },

                   new ToDoNote
                   {
                       Title = "Decide which clothes throw out",
                       Priority = "Not important not urgent",
                       DueDate = DateTime.Parse("2018-2-15"),
                       TaskDescription = "Check out the wardrobe to find some old waste things",
                       DutyHolder = "FS",
                       InProgress = true,
                       Done = false
                   }
                );
                context.SaveChanges();
            }
        }
    }
}