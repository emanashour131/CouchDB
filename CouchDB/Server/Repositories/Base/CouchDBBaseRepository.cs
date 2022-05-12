namespace CouchDB.Server;
public class CouchDBBaseRepository<TEntity>: ICouchDBBaseRepository<TEntity> 
    where TEntity : BaseEntity
{ 
    private readonly ICluster _cluster;
    private readonly ICouchbaseCollection _collection;
    public CouchDBBaseRepository(ICluster cluster,ICouchbaseCollection collection)
    {
        _cluster = cluster;
        _collection = collection;
    } 

    public async Task<TEntity> Add(TEntity entity)
    {
        await _collection.InsertAsync(entity.Id.ToString(), entity);
        return entity;
    }
    public async Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities)
    {
        entities.Select(e=> Add(e));
        return entities;
    }

    public async Task<TEntity> Delete(TEntity entity)
    {
        await _collection.RemoveAsync(entity.Id.ToString());
        return entity;
    }
    public async Task<IEnumerable<TEntity>> Delete(IEnumerable<TEntity> entities)
    {
        entities.Select(e => Delete(e));
        return entities;
    }
    //public async Task<IEnumerable<TEntity>> Get()
    //{
    //    IGetResult result = await _collection.GetAsync("document-key");
    //    IEnumerable<TEntity> sResult = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(result.ToString());
    //    //var content = result.ContentAs<String>();

    //    return sResult;
    //}


    //public async Task<IEnumerable<TEntity>> Get()
    //{
    //    IQueryResult<dynamic> result = await _cluster.QueryAsync<dynamic>("SELECT t.* FROM `travel-sample` t");
    //   // IEnumerable<TEntity>? entities = result.ContentAs<IEnumerable<TEntity>>();
    //    return entities;
    //}

    public async Task<IEnumerable<TEntity>> Get()
    {
        IGetResult result = await _collection.GetAsync("document-key");
        IEnumerable<TEntity>? entities = result.ContentAs<IEnumerable<TEntity>>();
        return entities;
    }
    public async Task<TEntity> Get(Guid id)
    {
        IGetResult result = await _collection.GetAsync(id.ToString());
        TEntity entity = result.ContentAs<TEntity>();
        return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        await _collection.UpsertAsync("document-key", entity);
        return entity;
    }
    public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entities)
    {
        entities.Select(e => Update(e));
        return entities;
    }

}
