namespace CouchDB.Server;

[Route("api/[controller]")]
[ApiController]
public class BooksController : BaseController<Book>
{
    public BooksController(CouchDBBaseRepository<Book> bookRepository) : base(bookRepository) { }
}