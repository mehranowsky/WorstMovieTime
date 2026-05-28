using AutoMapper;
using ModelLayer.Context;
using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Utilities;

namespace ServiceLayer.Services
{
    public class UserService : GenericService<Users>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly WorstMoviesDbContext _context;
        public UserService(WorstMoviesDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public OperationResult Register(RegisterViewModel registerInfo)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(e => e.PhoneNumber == registerInfo.PhoneNumber);
                if (existingUser != null)
                {
                    return OperationResult.Error("کاربری با این شماره موبایل وجود دارد!");
                }

                var newUser = _mapper.Map<Users>(registerInfo);
                newUser.Role = Users.UserRole.User;
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }
        public OperationResult Login(LoginViewModel loginInfo)
        {
            try
            {
                var user = _context.Users.Any(e => e.PhoneNumber == loginInfo.PhoneNumber);
                if (user)
                {
                    return OperationResult.Success();
                }
                return OperationResult.NotFound("کاربری با این اطلاعات یافت نشد!");
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        public string SendOTP()
        {
            string code = new Random().Next(100000, 1000000).ToString();
            return code;
        }

    }
}
