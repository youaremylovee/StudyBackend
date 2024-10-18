using Microsoft.EntityFrameworkCore;
using QuanLyVatPhamAPI.Models.Item;
using QuanLyVatPhamAPI.Filter;
using QuanLyVatPhamAPI.Filter.ItemFilter;
using System.Linq;

namespace QuanLyVatPhamAPI.Repository.ItemRepository
{
	public class ItemRepository : BaseRepository<Item>
	{
		public ItemRepository(ItemContext context) : base(context)
		{
			base._context = context;
		}
		public override IEnumerable<Item> Filter(BaseFilter filter)
		{
            ItemFilter f = filter as ItemFilter;
			ArgumentNullException.ThrowIfNull(f, nameof(f));
			var queryable = _context.Set<Item>().AsQueryable();
			if(!string.IsNullOrEmpty(f.CategoryId))
			{
				queryable = queryable.Where(m => m.CategoryItem != null && m.CategoryItem.ID == f.CategoryId);
			}
			if(f.StartPrice != int.MinValue)
			{
                queryable = queryable.Where(m => m.GiaTriGoc >= f.StartPrice);
            }
			if(f.EndPrice != int.MaxValue)
			{
                queryable = queryable.Where(m => m.GiaTriGoc <= f.EndPrice);
            }
			if(!string.IsNullOrEmpty(f.Status))
			{
                queryable = queryable.Where(m => m.TinhTrang.Trim().Equals(f.Status.Trim(), StringComparison.OrdinalIgnoreCase));
            }
			if(!string.IsNullOrEmpty(f.Name))
			{
                queryable = queryable.Where(m => m.Ten.Contains(f.Name));
            }
			if(f.DateStart != null)
			{
				queryable = queryable.Where(m => m.NgaySoHuu >= f.DateStart);
			}
			if(f.DateEnd != null)
			{
                queryable = queryable.Where(m => m.NgaySoHuu <= f.DateEnd);
            }
            var skip = (f.PagingOptions.Page - 1) * f.PagingOptions.PerPage;
			queryable = queryable.Skip(skip).Take(f.PagingOptions.PerPage);
			queryable = queryable.Include(item => item.CategoryItem);
			return queryable.ToList();
		}

		public override IEnumerable<Item> Paging(int page, int size)
		{
            var skip = (page - 1) * size;
            var queryable = _context.Set<Item>().Skip(skip).Take(size);
            return queryable.ToList();
        }

		public override void Update(Item entity)
		{
			base.Update(entity);
		}
        public override async Task<Item?> GetAsync(string id)
        {
            var item = await base.GetAsync(id);
			if (item != null) 
			{
				item.CategoryItem = _context.Set<CategoryItem>().Find(item.DanhMuc);
			}
			return item;
        }
    }
}
