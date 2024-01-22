using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;

namespace Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public IList<ProductReturnViewModel> Get()
        {
            return (from i in _context.Products
                    select new ProductReturnViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description,
                        Price = i.Price,
                        BrandId = i.BrandId
                    }).ToList();
        }
    }
}