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
    public class IndexModel : PageModel
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public IndexModel(ProcessClone.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Component> Component { get;set; }

        public async Task OnGetAsync()
        {
            Component = await _context.Component.ToListAsync();
        }
    }
}
