namespace CouchDB.Server;
public interface  ICouchDBBaseRepository<TEntity> 
    where TEntity : class
{
    Task<TEntity> Add(TEntity entity);
    Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);

    Task<IEnumerable<TEntity>> Get();
    Task<TEntity> Get(Guid id);

    Task<TEntity> Update(TEntity entity);
    Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entities);

    Task<TEntity> Delete(TEntity entity);
    Task<IEnumerable<TEntity>> Delete(IEnumerable<TEntity> entities);
}

