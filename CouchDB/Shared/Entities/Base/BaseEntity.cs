namespace CouchDB.Shared;
public abstract class BaseEntity
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; set; }
    [JsonProperty(PropertyName = "rev")]
    public string Rev { get; set; }

}
