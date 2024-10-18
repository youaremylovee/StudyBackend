namespace QuanLyVatPhamAPI.Filter.ItemFilter
{
	public class ItemFilterBuilder: FilterBuilder
	{
		protected override BaseFilter FC { get; set; } = new ItemFilter();
		private ItemFilter F => (ItemFilter)FC;
		public ItemFilterBuilder ByCategory(string category)
		{
            F.CategoryId = category;
            return this;
        }
		public ItemFilterBuilder ByStartPrice(int startPrice)
		{
            F.StartPrice = startPrice;
            return this;
        }
		public ItemFilterBuilder ByEndPrice(int endPrice)
		{
            F.EndPrice = endPrice;
            return this;
        }
		public ItemFilterBuilder ByStatus(string status)
		{
			F.Status = status;
			return this;
		}
	}
}
