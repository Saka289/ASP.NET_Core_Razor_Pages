﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccesss.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Category> Category { get; set; }

		public DbSet<FoodType> FoodType { get; set; }

		public DbSet<MenuItem> MenuItem { get; set; }

		public DbSet<ApplicationUser> ApplicationUser { get; set; }

		public DbSet<ShoppingCart> ShoppingCart { get; set; }

		public DbSet<OrderHeader> OrderHeader { get; set; }

		public DbSet<OrderDetails> OrderDetails { get; set; }

		public DbSet<Ingredient> Ingredient { get; set;}

		public DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }
	}
}
