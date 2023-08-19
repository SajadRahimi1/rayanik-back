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

    public async Task<CustomActionResult> editBook(EditBookDto editBookDto)
    {
        var book = await _appDbContext.Books.SingleOrDefaultAsync(_ => _.Id == editBookDto.Id);
        if (book == null)
        {
            return new CustomActionResult(new Result { ErrorMessage = new ErrorModel { ErrorMessage = "کتاب یافت نشد" }, statusCodes = 404 });
        }

        if (editBookDto.image == null)
        {
            editBookDto.imageUrl = book.imageUrl;
        }
        else
        {
            var imageUrl = await _fileRepository.SaveFileAsync(editBookDto.image);
            editBookDto.imageUrl = imageUrl;
            _fileRepository.DeleteFile(book.imageUrl);
        }


        if (editBookDto.pdf == null)
        {
            editBookDto.downloadUrl = book.downloadUrl;
        }
        else
        {
            var pdfUrl = await _fileRepository.SaveFileAsync(editBookDto.pdf);
            editBookDto.downloadUrl = pdfUrl;
            _fileRepository.DeleteFile(book.downloadUrl);
        }
        var mapBook = _mapper.Map<Book>(editBookDto);
        _appDbContext.ChangeTracker.Clear();
        var editedBook = _appDbContext.Books.Update(mapBook);
        await _appDbContext.SaveChangesAsync();
        return new CustomActionResult(new Result { Data = editedBook.Entity });

    }

    public async Task<CustomActionResult> getAllBooks()
    {
        var books = await _appDbContext.Books.ToListAsync();
        return new CustomActionResult(new Result { Data = books });
    }
}
