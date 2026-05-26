using ModelLayer.Models;
using ModelLayer.Models.ViewModels;

namespace ServiceLayer.Services
{
    public interface IUserService : IGenericService<Users>
    {
        bool Register(RegisterViewModel registerInfo);
        bool Login(LoginViewModel loginInfo);
    }
}
