using Microsoft.EntityFrameworkCore;
using System;

namespace BranchTask
{
	public class BranchContext : DbContext
	{
		public DbSet<Branch> Branch => Set<Branch>();

		public BranchContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Branch>().HasKey(b => b.BranchId);


			



		}
	}
}
