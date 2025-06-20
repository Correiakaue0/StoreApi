using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.ViewModel;

namespace Domain.Interfaces.Services
{
    public interface IBrandService
    {
        IList<BrandReturnViewModel> Get();
        BrandReturnViewModel? GetById(long id);
        void Create(BrandViewModel brandViewModel);
        void Update(long id, BrandViewModel brandViewModel);
        void Delete(long id);
    }
}