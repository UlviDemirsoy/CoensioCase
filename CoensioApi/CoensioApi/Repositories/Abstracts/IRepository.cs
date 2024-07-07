using System.Linq.Expressions;

namespace CoensioApi.Repositories.Abstracts
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        Task AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task<T> FindAsync(Expression<Func<T, bool>> lamda);
        Task<List<T>> ListAsync();
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> lamda);
        int Save();
        Task<int> SaveAsync();
    }
}
