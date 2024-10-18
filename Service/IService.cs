
using QuanLyVatPhamAPI.Filter;

namespace QuanLyVatPhamAPI.Service
{
    public interface IService<T> where T : class
    {
		void Update(T entity);
		void Delete(string id);
		Task<T?> GetAsync(string id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Paging(int page, int size);
		IEnumerable<T> Filter(BaseFilter filter);
		Task AddAsync(T entity);
	}
}
