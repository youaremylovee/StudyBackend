namespace QuanLyVatPhamAPI.Filter
{
	public interface IFilterBuilder
	{
		IFilterBuilder SetDateStart(DateTime dateStart);
		IFilterBuilder SetDateEnd(DateTime dateEnd);
		IFilterBuilder ByName(string name);
		IFilterBuilder Paging(PagingOptions pagingOptions);
		BaseFilter Build();
	}
}
