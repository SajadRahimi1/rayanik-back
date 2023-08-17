public interface IBookRepository 
{
    Task<CustomActionResult> addBook(AddBookDto addBookDto);
    Task<CustomActionResult> getAllBook();
    Task<CustomActionResult> editBook();

}
