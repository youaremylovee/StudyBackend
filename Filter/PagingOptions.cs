using System.Text.Json.Serialization;

namespace QuanLyVatPhamAPI.Filter
{
    public class PagingOptions
    {
        private int perpage = 10;
        private int page = 1;
        [JsonPropertyName("page")]
        public int Page
        {
            get
            {
                return page;
            }
            set
            {
                page = value < 1 ? 1 : value;
            }
        }
        [JsonPropertyName("per_page")]
        public int PerPage
        {
            get
            {
                return perpage;
            }
            set
            {
                value = value < 1 ? 1 : value;
                value = value > 20 ? 20 : value;
                perpage = value;
            }
        }
    }
}
