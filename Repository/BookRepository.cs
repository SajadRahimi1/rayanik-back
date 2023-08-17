using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IFileRepository _fileRepository;

    public BookRepository(AppDbContext appDbContext,IFileRepository fileRepository)
    {
        _appDbContext = appDbContext;
        _fileRepository=fileRepository;
    }


    public Task<CustomActionResult> addBook()
    {
        throw new NotImplementedException();
    }

    public Task<CustomActionResult> editBook()
    {
        throw new NotImplementedException();
    }

    public async Task<CustomActionResult> getAllBook()
    {
        var books = await _appDbContext.Books.ToListAsync();
        return new CustomActionResult(new Result{Data=books});
    }
}
