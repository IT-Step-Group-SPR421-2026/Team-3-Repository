using Shop_mvc_pv421.Interfaces;
using Shop_mvc_pv421.Data;

namespace Shop_mvc_pv421.Services
{
    public class ProductService
    {
        private readonly ShopDbContext ctx;
        private readonly IFileService fileService;

        public ProductService(ShopDbContext ctx, IFileService fileService)
        {
            this.ctx = ctx;
            this.fileService = fileService;
        }

        public async Task CleanUpProductImages()
        {
            var imagePaths = ctx.Products.Select(x => x.ImageUrl).ToArray();
            await fileService.DeleteProductImageExcept(imagePaths);
        }
    }
}
