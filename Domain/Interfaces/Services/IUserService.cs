using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        void Create(UserSaveViewModel userSaveViewModel);
        IList<UserReturnViewModel> Get();
        UserReturnViewModel? GetById(long id);
    }
}