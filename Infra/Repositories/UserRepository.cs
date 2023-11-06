using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IList<UserReturnViewModel> Get()
        {
            return (from i in _context.Users
                    select new UserReturnViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Email = i.Email,
                        Password = i.Password,
                    }).ToList();
        }

        public UserReturnViewModel? GetById(long id)
        {
            return (from i in _context.Users
                    where i.Id == id
                    select new UserReturnViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Email = i.Email,
                        Password = i.Password,
                    }).FirstOrDefault();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}