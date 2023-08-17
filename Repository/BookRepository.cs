using Microsoft.EntityFrameworkCore;
using AutoMapper;


public class BookRepository : IBookRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IFileRepository _fileRepository;
    private readonly IMapper _mapper;

    public BookRepository(AppDbContext appDbContext, IFileRepository fileRepository, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _fileRepository = fileRepository;
        _mapper = mapper;
    }


    public async Task<CustomActionResult> addBook(AddBookDto addBookDto)
    {
        var pdfUrl = await _fileRepository.SaveFileAsync(addBookDto.pdf);
        var imageUrl = await _fileRepository.SaveFileAsync(addBookDto.image);
        addBookDto.downloadUrl = pdfUrl;
        addBookDto.imageUrl = imageUrl;
        var createdBook = await _appDbContext.Books.AddAsync(_mapper.Map<Book>(addBookDto));
        await _appDbContext.SaveChangesAsync();
        return new CustomActionResult(new Result { Data = createdBook.Entity });
    }

    public Task<CustomActionResult> editBook()
    {
        throw new NotImplementedException();
    }

    public async Task<CustomActionResult> getAllBooks()
    {
        var books = await _appDbContext.Books.ToListAsync();
        return new CustomActionResult(new Result { Data = books });
    }
}
