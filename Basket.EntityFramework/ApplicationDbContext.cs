using Basket.Core.Entity.Catogry;
using Basket.Core.Entity.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
		public DbSet<Product> Products { get; set; }
		public DbSet<Offer> Offers { get; set; }
		public DbSet<AttributeTitle> Attributes { get; set; }
		public DbSet<AttributeValue> AttributeValues { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Area> Areas { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartProduct> CartProducts { get; set; }
		public DbSet<FavouriteStore> FavouriteStores { get; set; }
		public DbSet<FavouriteStoreList> FavouriteStoreLists { get; set; }
		public DbSet<WishList> WishLists { get; set; }
		public DbSet<WishListProduct> WishListProducts { get; set; }

		public DbSet<Anounance> Anounances { get; set; }
		public DbSet<AnounanceItem> AnounanceItems { get; set; }
	}
}
