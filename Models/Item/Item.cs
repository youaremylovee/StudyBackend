using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuanLyVatPhamAPI.Models.Item
{
	public class Item
	{
		[Key]
		[JsonIgnore]
		public string ID { get; set; } = string.Empty;
		public string Ten { get; set; } = string.Empty;
		public string DonViTinh { get; set; } = string.Empty;
		public double SoLuong { get; set; } = 1;
		public string TinhTrang { get; set; } = string.Empty;
		public string? ThongTinThem { get; set; } = string.Empty;
		[JsonPropertyName("NgayTao")]
		public DateTime? NgaySoHuu { get; set; }
		public DateTime? NgayCapNhat { get; set; }
		public string ViTri { get; set; } = string.Empty;
		public DateTime? HanSuDung { get; set; }
		public string? HinhAnh { get; set; } = string.Empty;
		public int? GiaTriGoc { get; set; } = 0;
		public string? GhiChu { get; set; } = string.Empty;
		[JsonIgnore]
		public string DanhMuc { get; set; } = string.Empty;
		[NotMapped]
		[JsonPropertyName("DanhMuc")]
		public CategoryItem? CategoryItem { get; set; } = new CategoryItem();
	}
}
