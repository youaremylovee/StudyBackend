using System.ComponentModel.DataAnnotations;

namespace QuanLyVatPhamAPI.Models.Item
{
	public class ConfigItem
	{
		[Key]
		public string ID { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;
	}
}
