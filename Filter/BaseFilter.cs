using System.Text.Json.Serialization;

namespace QuanLyVatPhamAPI.Filter
{
	public class BaseFilter
	{
        [JsonPropertyName("keyword")]
        public string? Name { get; set; }
        [JsonPropertyName("fromDate")]
        public DateTime? DateStart { get; set; }
        [JsonPropertyName("toDate")]
        public DateTime? DateEnd { get; set; } 
		public PagingOptions PagingOptions { get; set; } = new PagingOptions();
	}
}
