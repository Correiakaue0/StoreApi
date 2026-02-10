using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Utils;
using Domain.ViewModels.ViewModel;

namespace Service.Services
{
    public class LoginService : BaseService, ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(LoginViewModel loginViewModel)
        {
            var user = _userRepository.GetByEmail(loginViewModel.Email);
            if (user == null) throw new Exception(TranslateAsync($"{nameof(LoginViewModel.Email)} does not exist.").Result);

            if (!PasswordService.VerifyPassword(loginViewModel.Password, user.Password)) throw new Exception(TranslateAsync($"{nameof(LoginViewModel.Password)} incorrect.").Result);

            DataSession.Language = user.Language;
            DataSession.Email = user.Email;

            return TokenService.GerarToken(user);
        }
    }
}