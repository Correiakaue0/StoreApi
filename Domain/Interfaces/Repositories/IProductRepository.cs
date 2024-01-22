using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IList<ProductReturnViewModel> Get();
    }
}