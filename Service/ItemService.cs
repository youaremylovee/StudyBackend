using QuanLyVatPhamAPI.Filter;
using QuanLyVatPhamAPI.Models.Item;
using QuanLyVatPhamAPI.Repository;
using QuanLyVatPhamAPI.Repository.ItemRepository;

namespace QuanLyVatPhamAPI.Service
{
	public class ItemService: BaseService<Item>
	{
		public ItemService(IRepository<Item> repository) : base(repository)
		{

		}
    }
}
