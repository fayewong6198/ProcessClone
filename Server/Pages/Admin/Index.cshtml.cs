using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProcessClone.Server.Models;


namespace ProcessClone.Server.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel(ILogger<IndexModel> logger,
         UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
             _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {

            return Page();

        }
    }
}
