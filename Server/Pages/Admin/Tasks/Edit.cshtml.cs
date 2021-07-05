using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.Admin.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public EditModel(ProcessClone.Server.Data.ApplicationDbContext context)
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
           ViewData["AssigneeId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
           ViewData["ComponentId"] = new SelectList(_context.Component, "Id", "Name");
           ViewData["GrandMasterId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
           ViewData["MasterId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoTaskExists(ToDoTask.Id))
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

        private bool ToDoTaskExists(int id)
        {
            return _context.ToDoTask.Any(e => e.Id == id);
        }
    }
}
