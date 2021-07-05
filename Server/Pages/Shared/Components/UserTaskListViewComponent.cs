using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProcessClone.Server.Data;
using ProcessClone.Server.Models;

namespace ProcessClone.Server.Pages.Shared.Components
{
    public class UserTaskListViewComponent : ViewComponent
    {
        private readonly ProcessClone.Server.Data.ApplicationDbContext _context;

        public UserTaskListViewComponent(ProcessClone.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDoTask> ToDoTask { get;set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private async Task<IList<ToDoTask>> GetItemsAsync()
        {
            return ToDoTask = await _context.ToDoTask
                .Include(t => t.Assignee)
                .Include(t => t.Component)
                .Include(t => t.GrandMaster)
                .Include(t => t.Master).ToListAsync();
        }
    }
}
