using Common.Repository;
using ProductMicroservice.DataAccess.Entities;

namespace ProductMicroservice.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
