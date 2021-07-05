using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.Admin.Components
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
            return Page();
        }

        [BindProperty]
        public Component Component { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Component.Add(Component);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
