using Common.Repository;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.DataAccess.Repositories
{
    public interface IProductViewRepository : IRepository<ProductView>
    {
        IEnumerable<ProductView> GetByIdList(int[] ids);
    }
}
