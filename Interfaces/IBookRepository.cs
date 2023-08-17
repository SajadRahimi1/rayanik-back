public interface IBookRepository 
{
    Task<CustomActionResult> addBook();
    Task<CustomActionResult> getAllBook();
    Task<CustomActionResult> editBook();

}
