using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Utilities;

namespace ServiceLayer.Services
{
    public interface IUserService : IGenericService<Users>
    {
        OperationResult Register(RegisterViewModel registerInfo);
        OperationResult Login(LoginViewModel loginInfo);
        Users GetUserByEmail(string email);
        Task<OperationResult> SendTokenEmail(string email);

        // Verify by phoneNumber
        //OperationResult Verify(VerifyViewModel model);
        //Task<string> SendOTP(string phoneNumber);
    }
}
