using Domain.Entities;
using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(User user);
        IList<UserReturnViewModel> Get();
        User? GetByEmail(string email);
        User? GetById(long id);
        void Update(User user);
    }
}