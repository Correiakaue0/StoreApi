using Domain.Entities;
using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Repositories
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        IList<BrandReturnViewModel> GetBrand();
    }
}