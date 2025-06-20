using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository 
    {
        public BrandRepository(Context context, ILogger<Brand> logger) : base(context, logger) { }

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