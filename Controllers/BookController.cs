using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> getAllBooks()
    {
        return await _bookRepository.getAllBooks();
    }

    [HttpPost, Route("create")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> createBook([FromForm] AddBookDto dto)
    {
        return await _bookRepository.addBook(dto);
    }
}
