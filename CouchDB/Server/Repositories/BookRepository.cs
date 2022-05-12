namespace CouchDB.Server;
public class BookRepository: CouchDBBaseRepository<Book>, IBookRepository
{
    public BookRepository(ICluster cluster,ICouchbaseCollection collection) : 
        base(cluster ,collection)
    {}
}
