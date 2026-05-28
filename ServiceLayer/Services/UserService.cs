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

        // Register operation
        public OperationResult Register(RegisterViewModel registerInfo)
        {
            try
            {
                var existingUser = _context.Users.Any(e => e.PhoneNumber == registerInfo.PhoneNumber);
                if (existingUser)                
                    return OperationResult.Error("کاربری با این شماره موبایل وجود دارد!");
                int otpCode = SendOTP(registerInfo.PhoneNumber);
                if (registerInfo.OTPCode != otpCode)                
                    return OperationResult.Error("کد تایید معتبر نمیباشد!");                    

                var newUser = _mapper.Map<Users>(registerInfo);                        
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        // Login operation
        public OperationResult Login(LoginViewModel loginInfo)
        {
            try
            {
                bool user = _context.Users.Any(e => e.PhoneNumber == loginInfo.PhoneNumber);
                if (!user)                
                    return OperationResult.NotFound("کاربری با این اطلاعات یافت نشد!");
                int otpCode = SendOTP(loginInfo.PhoneNumber);
                if (loginInfo.OTPCode != otpCode)
                    return OperationResult.Error("کد تایید معتبر نمیباشد!");

                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        public int SendOTP(string? phoneNumber)
        {
            using var client = new HttpClient();
            int code = new Random().Next(100000, 1000000);
            client.GetAsync($"http://localhost:5000/?code{code}");
            return code;
        }

    }
}
