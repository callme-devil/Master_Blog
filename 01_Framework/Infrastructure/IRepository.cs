using System.Linq.Expressions;
using _01_Framework.Domain;

namespace _01_Framework.Infrastructure
{
    public interface IRepository<in TKey,T> where T : DomainBase<TKey>
    {
        void Create(T entity);

        T Get(TKey id);

        List<T> GetList();

        bool Exists(Expression<Func<bool, T>> expression);

        
    }
}
