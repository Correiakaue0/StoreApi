using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.ViewModel;

namespace Domain.Interfaces.Services
{
    public interface IBrandService
    {
        void Create(BrandViewModel brandViewModel);
        void Delete(long id);
        IList<BrandReturnViewModel> Get();
        BrandReturnViewModel? GetById(long id);
        void Update(long id, BrandViewModel brandViewModel);
    }
}