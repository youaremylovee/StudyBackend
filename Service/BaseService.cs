using QuanLyVatPhamAPI.Filter;
using QuanLyVatPhamAPI.Repository;

namespace QuanLyVatPhamAPI.Service
{
	public class BaseService<T> : IService<T> where T : class
	{
		protected IRepository<T> _repository;
		public BaseService(IRepository<T> repository)
		{
			_repository = repository;
		}
		public Task AddAsync(T entity)
		{
			return _repository.AddAsync(entity);
		}

		public void Delete(string id)
		{
			_repository.Delete(id);
		}

		public virtual IEnumerable<T> Filter(BaseFilter filter)
		{
			return _repository.Filter(filter);
		}

		public IEnumerable<T> GetAll()
		{
			return _repository.GetAll();
		}

		public Task<T?> GetAsync(string id)
		{
			return _repository.GetAsync(id);
		}

		public IEnumerable<T> Paging(int page, int size)
		{
			return _repository.Paging(page, size);
		}

		public virtual void Update(T entity)
		{
			_repository.Update(entity);
		}
	}
}
