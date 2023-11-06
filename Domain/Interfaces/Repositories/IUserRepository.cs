using Domain.Entities;
using Domain.ViewModels.ReturnViewModels;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        IList<UserReturnViewModel> Get();
        UserReturnViewModel? GetById(long id);
    }
}