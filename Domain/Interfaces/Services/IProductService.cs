using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        IList<ProductReturnViewModel> Get();
    }
}