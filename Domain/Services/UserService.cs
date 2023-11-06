using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository; 
        }

        public IList<UserReturnViewModel> Get()
        {
            return _userRepository.Get();
        }

        public UserReturnViewModel? GetById(long id)
        {
            return _userRepository.GetById(id);
        }

        public void Create(UserSaveViewModel userSaveViewModel)
        {
            var user = new User
            {
                Name = userSaveViewModel.Name,
                Email = userSaveViewModel.Email,
                Password = userSaveViewModel.Password
            };

            _userRepository.Create(user);
        }
    }
}
