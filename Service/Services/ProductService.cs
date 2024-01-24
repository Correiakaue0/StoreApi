using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ReturnViewModels;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<ProductReturnViewModel> Get()
        {
            return _productRepository.Get();
        }
    }
}