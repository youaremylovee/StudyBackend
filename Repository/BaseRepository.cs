using QuanLyVatPhamAPI.Filter;
using Microsoft.EntityFrameworkCore;

namespace QuanLyVatPhamAPI.Repository
{
	public class BaseRepository<T> : IRepository<T> where T : class
	{
		protected DbContext _context;
		public BaseRepository(DbContext context)
		{
			this._context = context;
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public virtual async Task<T?> GetAsync(string id)
		{
			return await _context.Set<T>().FindAsync(id); 
		}

		public async void Delete(string id)
		{
			var item = await GetAsync(id);
			if(item == null)
			{
				return;
			}
			_context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

		public virtual IEnumerable<T> Filter(BaseFilter filter)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>();
		}

		public virtual IEnumerable<T> Paging(int page, int size)
		{
			throw new NotImplementedException();
		}

		public virtual void Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
