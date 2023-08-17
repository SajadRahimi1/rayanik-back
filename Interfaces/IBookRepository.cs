public interface IBookRepository
{
    Task<CustomActionResult> addBook(AddBookDto addBookDto);
    Task<CustomActionResult> getAllBooks();
    Task<CustomActionResult> editBook();

}
