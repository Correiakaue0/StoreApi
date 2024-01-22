using Domain.Entities;
using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        void Delete(Brand brand);
        IList<BrandReturnViewModel> Get();
        Brand? GetById(long id);
        void Update(Brand brand);
    }
}