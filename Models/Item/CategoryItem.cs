using System.ComponentModel.DataAnnotations;

namespace QuanLyVatPhamAPI.Models.Item
{
	public class CategoryItem
	{
		[Key]
		public string ID { get; set; } = string.Empty;
		public string TenDanhMuc { get; set; } = string.Empty;
	}
}
