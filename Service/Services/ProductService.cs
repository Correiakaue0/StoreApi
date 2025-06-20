using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.ViewModel;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;
        public IBrandRepository _brandRepository;

        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        public IList<ProductReturnViewModel> Get()
        {
            return _productRepository.GetProduct();
        }

        public ProductReturnViewModel? GetById(long id)
        {
            var product = _productRepository.GetById(id);

            if (product != null)
                return new ProductReturnViewModel
                {
                    Id = id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    BrandId = product.BrandId,
                };

            return null;
        }

        public void Create(ProductViewModel productViewModel)
        {
            var brand = _brandRepository.GetById(productViewModel.BrandId) ?? throw new Exception("Marca não encontrado.");

            var product = new Product
            {
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                Price = productViewModel.Price,
                BrandId = productViewModel.BrandId
            };

            _productRepository.Create(product);
        }

        public void Update(long id, ProductViewModel productViewModel)
        {
            var product = _productRepository.GetById(id) ?? throw new Exception("Produto não encontrado.");

            var brand = _brandRepository.GetById(productViewModel.BrandId) ?? throw new Exception("Marca não encontrado.");

            product.Name = productViewModel.Name;
            product.Description = productViewModel.Description;
            product.Price = productViewModel.Price;
            product.BrandId = productViewModel.BrandId;

            _productRepository.Update(product);
        }

        public void Delete(long id)
        {
            var product = _productRepository.GetById(id) ?? throw new Exception("Pruduto não encontrado.");

            _productRepository.Delete(product);
        }
    }
}