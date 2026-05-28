using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Utilities;

namespace ServiceLayer.Services
{
    public interface IUserService : IGenericService<Users>
    {
        OperationResult Register(RegisterViewModel registerInfo);
        OperationResult Login(LoginViewModel loginInfo);
    }
}
