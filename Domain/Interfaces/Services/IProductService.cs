using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.ViewModel;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        IList<ProductReturnViewModel> Get();
        ProductReturnViewModel? GetById(long id);
        void Create(ProductViewModel productViewModel);
        void Update(long id, ProductViewModel productViewModel);
        void Delete(long id);
    }
}