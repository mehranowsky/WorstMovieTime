using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using ModelLayer.Context;
using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Utilities;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService : GenericService<Users>, IUserService
    {
        private readonly WorstMoviesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public UserService(WorstMoviesDbContext context, IMapper mapper, IMemoryCache cache) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        // Register operation
        public async Task<OperationResult> Register(RegisterViewModel registerInfo)
        {
            try
            {
                var existingUser = _context.Users.Any(e => e.PhoneNumber == registerInfo.PhoneNumber);
                if (existingUser)
                    return OperationResult.Error("کاربری با این شماره موبایل وجود دارد!");

                string otpCode = await SendOTP(registerInfo.PhoneNumber);                
                string otpKey = $"otp:{registerInfo.PhoneNumber}";
                string registerKey = $"register:{registerInfo.PhoneNumber}";
                _cache.Set(
                    otpKey,
                    otpCode,
                    TimeSpan.FromMinutes(2));

                _cache.Set(
                    registerKey,
                    registerInfo,
                    TimeSpan.FromMinutes(10));
                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        // Login operation
        public async Task<OperationResult> Login(LoginViewModel loginInfo)
        {
            try
            {
                bool user = _context.Users.Any(e => e.PhoneNumber == loginInfo.PhoneNumber);
                if (!user)
                    return OperationResult.NotFound("کاربری با این اطلاعات یافت نشد!");
                string otpCode = await SendOTP(loginInfo.PhoneNumber);
                if (loginInfo.OTPCode != otpCode)
                    return OperationResult.Error("کد تایید معتبر نمیباشد!");

                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        public OperationResult Verify(VerifyViewModel model)
        {
            try
            {
                string otpKey = $"otp:{model.PhoneNumber}";
                string registerKey = $"register:{model.PhoneNumber}";
                if (!_cache.TryGetValue(otpKey, out string? storedOTP))
                    return OperationResult.Error("کد منقضی شده است!");
                if (storedOTP != model.OTPCode)
                    return OperationResult.Error("کد وارد شده نا معتبر است!");
                if (!_cache.TryGetValue(registerKey, out string? storedRegisterInfo))
                    return OperationResult.Error("شماره موبایل یافت نشد!");

                var newUser = _mapper.Map<Users>(storedRegisterInfo);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                _cache.Remove(otpKey);
                _cache.Remove(registerKey);
                return OperationResult.Success();
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        public async Task<string> SendOTP(string? phoneNumber)
        {
            using var client = new HttpClient();
            string code = new Random().Next(100000, 999999).ToString();            
            _cache.Set(phoneNumber, code, TimeSpan.FromMinutes(2));
            await client.GetAsync($"http://localhost:5000/?code={code}");
            return code;
        }

    }
}
