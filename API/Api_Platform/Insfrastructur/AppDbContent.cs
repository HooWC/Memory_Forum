using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DomainModelEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace Insfrastructur
{
	public class AppDbContext : DbContext
	{

		public AppDbContext()
		{

		}

		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Admin> Admins { get; set; } = null!;
		public DbSet<Friend> Friends { get; set; } = null!;
		public DbSet<Message> Messages { get; set; } = null!;
		public DbSet<MessageCall> MessageCalls { get; set; } = null!;
		public DbSet<PostWord> PostWords { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<PostWordData> PostWordDatas { get; set; } = null!;
		public DbSet<PostWordDataComment> PostWordDataComments { get; set; } = null!;
		public DbSet<SayHello> SayHellos { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=LAPTOP-75SCS0RS\\SQLEXPRESS;Database=Platform;Trusted_Connection=True;TrustServerCertificate=true");
			}
		}

	}
}
