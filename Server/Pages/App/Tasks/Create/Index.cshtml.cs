using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.App.Tasks.Create
{
    public class CreateModel : PageModel
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public CreateModel(ProcessClone.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AssigneeId"] = new SelectList(_context.ApplicationUser, "Id", "UserName");
            ViewData["ComponentId"] = new SelectList(_context.Component, "Id", "Name");
            ViewData["GrandMasterId"] = new SelectList(_context.ApplicationUser, "Id", "UserName");
            ViewData["MasterId"] = new SelectList(_context.ApplicationUser, "Id", "UserName");
            
            return Page();
        }

        [BindProperty]
        public IList<ToDoTask> ToDoTasks { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync( )
        {
            Console.WriteLine(ToDoTasks.Count);
            if (!ModelState.IsValid)
            {
                return OnGet();
            }

            for (int i = 0; i < ToDoTasks.Count; i++) {
                 _context.ToDoTask.Add(ToDoTasks[i]);
            }

            // _context.ToDoTask.Add(ToDoTask);
            await _context.SaveChangesAsync();

            return Redirect("/App");
        }
    }
}
