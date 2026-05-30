using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Utilities;

namespace ServiceLayer.Services
{
    public interface IUserService : IGenericService<Users>
    {
        Task<OperationResult> Register(RegisterViewModel registerInfo);
        Task<OperationResult> Login(LoginViewModel loginInfo);
        OperationResult Verify(VerifyViewModel model);
        Task<string> SendOTP(string phoneNumber);
    }
}
