public interface IFileRepository
{
    void DeleteFile(string filePath);
    Task<string> SaveFileAsync(IFormFile file);
    byte[] GetFile(string filePath);
}