using Common.Repository;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess.Repositories
{
    public class ProductViewRepository : RepositoryBase<ProductView>, IProductViewRepository
    {

        private readonly ViewContext _queryContext;
        public ProductViewRepository(ViewContext queryContext) : base(queryContext)
        {
            _queryContext = queryContext;
        }

        public IEnumerable<ProductView> GetByIdList(int[] ids)
        {
            return _queryContext.ProductViews.Where(x => ids.Contains(x.Id)).ToList();
        }

    }
}
