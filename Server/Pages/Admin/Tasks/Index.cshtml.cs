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
    public class IndexModel : PageModel
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public IndexModel(ProcessClone.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDoTask> ToDoTask { get;set; }

        public async Task OnGetAsync()
        {
            ToDoTask = await _context.ToDoTask
                .Include(t => t.Assignee)
                .Include(t => t.Component)
                .Include(t => t.GrandMaster)
                .Include(t => t.Master).ToListAsync();
        }
    }
}
