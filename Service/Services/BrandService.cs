using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.ViewModel;

namespace Service.Services
{
    public class BrandService : BaseService, IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IList<BrandReturnViewModel> Get()
        {
            return _brandRepository.GetBrand();
        }

        public BrandReturnViewModel? GetById(long id)
        {
            var brand = _brandRepository.GetById(id);

            if (brand != null)
                return new BrandReturnViewModel
                {
                    Id = id,
                    Code = brand.Code,
                    Description = brand.Description,
                };

            return null;
        }

        public void Create(BrandViewModel brandViewModel)
        {
            var brand = new Brand
            {
                Code = brandViewModel.Code,
                Description = brandViewModel.Description
            };

            _brandRepository.Create(brand);
        }

        public void Update(long id, BrandViewModel brandViewModel)
        {
            var brand = _brandRepository.GetById(id) ?? throw new Exception(MessageNotFound<Brand>());

            brand.Code = brandViewModel.Code;
            brand.Description = brandViewModel.Description;

            _brandRepository.Update(brand);
        }

        public void Delete(long id)
        {
            var brand = _brandRepository.GetById(id) ?? throw new Exception(MessageNotFound<Brand>());
            _brandRepository.Delete(brand);
        }
    }
}