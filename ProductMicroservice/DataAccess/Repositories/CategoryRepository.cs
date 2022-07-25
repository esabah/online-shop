using Common.Repository;
using ProductMicroservice.DataAccess.Entities;

namespace ProductMicroservice.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Product>, IProductRepository
    {
        public CategoryRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
