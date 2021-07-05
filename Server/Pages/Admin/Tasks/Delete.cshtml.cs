using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.Admin.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public DeleteModel(ProcessClone.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoTask ToDoTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoTask = await _context.ToDoTask
                .Include(t => t.Assignee)
                .Include(t => t.Component)
                .Include(t => t.GrandMaster)
                .Include(t => t.Master).FirstOrDefaultAsync(m => m.Id == id);

            if (ToDoTask == null)
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

            ToDoTask = await _context.ToDoTask.FindAsync(id);

            if (ToDoTask != null)
            {
                _context.ToDoTask.Remove(ToDoTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
