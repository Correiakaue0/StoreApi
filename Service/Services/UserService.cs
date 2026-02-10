using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ViewModels.ReturnViewModels;
using Domain.ViewModels.SaveViewModel;

namespace Service.Services
{
    public class UserService : BaseService, IUserService
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
            if (string.IsNullOrEmpty(userSaveViewModel.Password)) throw new Exception(MessageAlreadyRegistered(nameof(UserViewModel.Password)));

            if (_userRepository.GetByEmail(userSaveViewModel.Email) != null) throw new Exception(MessageAlreadyRegistered(nameof(UserViewModel.Email)));

            var user = new User
            {
                Name = userSaveViewModel.Name,
                Email = userSaveViewModel.Email,
                Role = "user",
                Password = PasswordService.HashPassword(userSaveViewModel.Password),
                Language = userSaveViewModel.Language,
            };

            _userRepository.Create(user);
        }

        public void Update(long id, UserViewModel userSaveViewModel)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception(MessageNotFound<User>());

            if(_userRepository.GetByEmail(userSaveViewModel.Email) != null) throw new Exception(MessageAlreadyRegistered(nameof(UserViewModel.Email)));

            user.Name = userSaveViewModel.Name;
            user.Email = userSaveViewModel.Email;
            user.Language = userSaveViewModel.Language;

            _userRepository.Update(user);
        }

        public void Delete(long id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) throw new Exception(MessageNotFound<User>());

            _userRepository.Delete(user);
        }
    }
}
