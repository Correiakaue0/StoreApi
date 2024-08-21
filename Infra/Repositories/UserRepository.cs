using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ViewModels.ReturnViewModels;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IList<UserReturnViewModel> GetAll()
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

        public User? GetById(long id)
        {
            return (from i in _context.Users
                    where i.Id == id
                    select i).FirstOrDefault();
        }

        public User? GetByEmail(string email)
        {
            return (from i in _context.Users
                    where i.Email == email
                    select i).FirstOrDefault();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}