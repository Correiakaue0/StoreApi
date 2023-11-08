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
            var user =_userRepository.GetById(id);
            if (user != null) 
                return new UserReturnViewModel
                {
                    Id = id,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password
                };

            return new UserReturnViewModel();
        }

        public void Create(UserSaveViewModel userSaveViewModel)
        {
            if (string.IsNullOrEmpty(userSaveViewModel.Password)) throw new Exception("Senha não pode ser vazio.");

            var user = new User
            {
                Name = userSaveViewModel.Name,
                Email = userSaveViewModel.Email,
                Password = userSaveViewModel.Password
            };

            _userRepository.Create(user);
        }

        public void Update(long id, UserSaveViewModel userSaveViewModel)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception("Usuario não encontrado.");

            user.Name = userSaveViewModel.Name;
            user.Email = userSaveViewModel.Email;

            _userRepository.Update(user);
        }

        public void Delete(long id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception("Usuario não encontrado.");

            _userRepository.Delete(user);
        }
    }
}
