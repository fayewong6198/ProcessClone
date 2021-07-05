using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.Admin.Tasks
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
        ViewData["AssigneeId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
        ViewData["ComponentId"] = new SelectList(_context.Component, "Id", "Name");
        ViewData["GrandMasterId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
        ViewData["MasterId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ToDoTask ToDoTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoTask.Add(ToDoTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
