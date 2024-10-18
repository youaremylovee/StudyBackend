using QuanLyVatPhamAPI.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace QuanLyVatPhamAPI.Repository.ItemRepository
{
	public class ItemContext: DbContext
	{
		public ItemContext(DbContextOptions<ItemContext> options): base(options)
		{

		}
		public DbSet<Item> Items { get; set; }
		public DbSet<ConfigItem> ConfigItems { get; set; }
		public DbSet<CategoryItem> CategoryItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Item>().ToTable("VatPham");
			modelBuilder.Entity<ConfigItem>().ToTable("Config");
			modelBuilder.Entity<CategoryItem>().ToTable("DanhMuc");
			modelBuilder.Entity<Item>()
				.HasOne(item => item.CategoryItem)
				.WithMany()
				.HasForeignKey(item => item.DanhMuc);
			base.OnModelCreating(modelBuilder);
		}
	}
}
