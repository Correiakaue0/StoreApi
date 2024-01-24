using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;

namespace Infra.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository 
    {
        public BrandRepository(Context context) : base(context) { }

        public IList<BrandReturnViewModel> GetBrand()
        {
            return (from i in Get()
                    select new BrandReturnViewModel
                    {
                        Id = i.Id,
                        Code = i.Code,
                        Description = i.Description
                    }).ToList();
        }
    }
}