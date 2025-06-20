using Domain.Entities;
using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IList<ProductReturnViewModel> GetProduct();
    }
}