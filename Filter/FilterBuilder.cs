
namespace QuanLyVatPhamAPI.Filter
{
	public abstract class FilterBuilder: IFilterBuilder
	{
		protected virtual BaseFilter FC { get; set; }

		public BaseFilter Build()
		{
			return FC;
		}

		public IFilterBuilder ByName(string name)
		{
			FC.Name = name;
			return this;
		}

        public IFilterBuilder Paging(PagingOptions pagingOptions)
        {
            FC.PagingOptions = pagingOptions;
			return this;
        }

        public IFilterBuilder SetDateEnd(DateTime dateEnd)
		{
			FC.DateEnd = dateEnd;
			return this;
		}

		public IFilterBuilder SetDateStart(DateTime dateStart)
		{
			FC.DateStart = dateStart;
			return this;
		}
	}
}
