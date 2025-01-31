using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;

namespace Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context) { }

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