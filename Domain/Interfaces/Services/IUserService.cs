using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        void Create(UserSaveViewModel userSaveViewModel);
        void Delete(long id);
        IList<UserReturnViewModel> Get();
        UserReturnViewModel? GetById(long id);
        void Update(long id, UserSaveViewModel userSaveViewModel);
    }
}