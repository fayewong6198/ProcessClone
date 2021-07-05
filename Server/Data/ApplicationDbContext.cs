using ProcessClone.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessClone.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<ProcessClone.Server.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ProcessClone.Server.Models.Component> Component { get; set; }
        public DbSet<ProcessClone.Server.Models.ToDoTask> ToDoTask { get; set; }
    }
}
