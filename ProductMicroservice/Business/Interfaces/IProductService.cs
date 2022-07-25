using ProductMicroservice.Business.Dtos;

namespace ProductMicroservice.Business.Interfaces
{
    public interface IProductService
    {
        int Create(ProductDto productDto);
        IEnumerable<ProductDto> GetAll();
    }
}
