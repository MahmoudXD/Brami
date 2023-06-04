using Basket.Core.Entity.Catogry;
using Basket.Core.Entity.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<MainCatogry> MainCatogries { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
