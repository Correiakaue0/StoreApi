using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository; 
        }

        public IList<UserReturnViewModel> GetAll()
        {
            return _userRepository.GetAll();
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
                    Role = user.Role,
                    Password = user.Password
                };

            return null;
        }

        public void Create(UserViewModel userSaveViewModel)
        {
            if (string.IsNullOrEmpty(userSaveViewModel.Password)) throw new Exception("Senha não pode ser vazio.");

            if (_userRepository.GetByEmail(userSaveViewModel.Email) != null) throw new Exception("Email já cadastrado.");

            var user = new User
            {
                Name = userSaveViewModel.Name,
                Email = userSaveViewModel.Email,
                Role = "user",
                Password = PasswordService.HashPassword(userSaveViewModel.Password)
            };

            _userRepository.Create(user);
        }

        public void Update(long id, UserViewModel userSaveViewModel)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception("Usuario não encontrado.");

            if(_userRepository.GetByEmail(userSaveViewModel.Email) != null) throw new Exception("Email já cadastrado.");

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
