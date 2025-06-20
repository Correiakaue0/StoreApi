using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context, ILogger<Product> logger) : base(context, logger) { }

        public IList<ProductReturnViewModel> GetProduct()
        {
            return (from i in Get()
                    select new ProductReturnViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description,
                        Price = i.Price,
                        BrandId = i.BrandId,
                    }).ToList();
        }
    }
}