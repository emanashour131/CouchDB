namespace CouchDB.Server;
public class CouchDbUtilities<TEntity>
    where TEntity : BaseEntity
{
    public static async Task<CouchDBBaseRepository<TEntity>> InitializeCouchClientInstanceAsync()
    {
        String endpoint = "cb.nmynv9awy4dhgmbk.cloud.couchbase.com";
        String bucketName = "Books";
        String username = "wael@innotech.com.eg";
        String password = "ZVf$Ygdp4rVx3H";

        ClusterOptions opts = new ClusterOptions().WithCredentials(username, password);
        opts.IgnoreRemoteCertificateNameMismatch = true;

        ICluster cluster = await Cluster.ConnectAsync("couchbases://" + endpoint, opts);
        IBucket bucket = await cluster.BucketAsync(bucketName);
        ICouchbaseCollection collection = bucket.DefaultCollection();
    
        return new CouchDBBaseRepository<TEntity>(cluster,collection);
    }
   
}
