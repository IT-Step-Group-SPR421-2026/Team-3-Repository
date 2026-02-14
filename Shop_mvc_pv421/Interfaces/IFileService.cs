namespace Shop_mvc_pv421.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveImage(IFormFile file);
        Task DeleteImage(string path);
        Task DeleteProductImageExcept(string?[] exeptFiles);
    }
}