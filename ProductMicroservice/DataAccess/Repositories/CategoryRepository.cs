using Common.Repository;
using ProductMicroservice.DataAccess.Entities;

namespace ProductMicroservice.DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
