using ProductMicroservice.Business.Dtos;

namespace ProductMicroservice.Business.Interfaces
{
    public interface ICategoryService
    {
        int Create(CategoryDto categoryDto);
    }
}
