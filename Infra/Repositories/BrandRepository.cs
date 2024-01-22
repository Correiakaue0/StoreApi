using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;

namespace Infra.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly Context _context;

        public BrandRepository(Context context)
        {
            _context = context;
        }

        public IList<BrandReturnViewModel> Get()
        {
            return (from i in _context.Brands
                    select new BrandReturnViewModel
                    {
                        Id = i.Id,
                        Code = i.Code,
                        Description = i.Description
                    }).ToList();
        }

        public Brand? GetById(long id)
        {
            return (from i in _context.Brands
                    where i.Id == id
                    select i).FirstOrDefault();
        }

        public void Create(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }

        public void Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }
    }
}