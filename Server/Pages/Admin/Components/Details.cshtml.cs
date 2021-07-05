using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.Admin.Components
{
    public class DetailsModel : PageModel
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public DetailsModel(ProcessClone.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Component Component { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Component = await _context.Component.FirstOrDefaultAsync(m => m.Id == id);

            if (Component == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
