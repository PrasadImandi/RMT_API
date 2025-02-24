namespace RMT_API.Repositories
{
	public interface IRepositoryFactory
	{
		IGenericRepository<T> GetRepository<T>() where T : class;
	}
}
