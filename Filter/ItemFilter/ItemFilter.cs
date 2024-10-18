
using System.Text.Json.Serialization;

namespace QuanLyVatPhamAPI.Filter.ItemFilter
{
	public class ItemFilter: BaseFilter
	{
		[JsonPropertyName("DanhMuc")]
		public string? CategoryId { get; set; } = string.Empty;
		[JsonPropertyName("GiaBatDau")]
		public int StartPrice { get; set; } = int.MinValue;
		[JsonPropertyName("GiaKetThuc")]
		public int EndPrice { get; set; } = int.MaxValue;
		[JsonPropertyName("TinhTrang")]
		public string? Status { get; set; } = string.Empty;
    }
}
