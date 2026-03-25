using System.Linq.Expressions;

namespace ITIEntities.Repo;

public interface IEntityRepo<T>
{
    List<T> GetAll(string navprop = null);
    IList<T> FindAll(Expression<Func<T, bool>> cond);
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}
