using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        void Create(UserViewModel userSaveViewModel);
        void Delete(long id);
        IList<UserReturnViewModel> GetAll();
        UserReturnViewModel? GetById(long id);
        void Update(long id, UserViewModel userSaveViewModel);
    }
}