using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using ModelLayer.Context;
using ModelLayer.Models;
using ModelLayer.Models.ViewModels;
using ServiceLayer.Utilities;
using static System.Net.WebRequestMethods;

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
        public OperationResult Register(RegisterViewModel registerInfo)
        {
            try
            {
                var existingUser = _context.Users.Any(e => e.Email == registerInfo.Email);
                if (existingUser)
                    return OperationResult.Error("کاربری با این ایمیل وجود دارد!");

                string hashedPassword = Hasher.hash(registerInfo.Password);
                Users newUser = _mapper.Map<Users>(registerInfo);
                newUser.Password = hashedPassword;
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
                string hashedPass = Hasher.hash(loginInfo.Password);
                bool user = _context.Users.Any(e => e.Email == loginInfo.Email && e.Password == hashedPass);
                if (user)
                    return OperationResult.Success();
                return OperationResult.NotFound("کاربری با این اطلاعات یافت نشد!");
            }
            catch (Exception)
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> SendTokenEmail(string email)
        {
            using var client = new HttpClient();
            string otpCode = new Random().Next(100000, 999999).ToString();
            _cache.Set($"email-otp:{email}", otpCode, TimeSpan.FromMinutes(5));
            await client.GetAsync($"http://localhost:5000/?code={otpCode}");
            return OperationResult.Success();
        }


        // Verify by phoneNumber
        //public OperationResult Verify(VerifyViewModel model)
        //{
        //    try
        //    {
        //        string otpKey = $"otp:{model.PhoneNumber}";
        //        string registerKey = $"register:{model.PhoneNumber}";
        //        if (!_cache.TryGetValue(otpKey, out string? storedOTP))
        //            return OperationResult.Error("کد منقضی شده است!");
        //        if (storedOTP != model.OTPCode)
        //            return OperationResult.Error("کد وارد شده نا معتبر است!");
        //        if (!_cache.TryGetValue(registerKey, out string? storedRegisterInfo))
        //            return OperationResult.Error("شماره موبایل یافت نشد!");

        //        var newUser = _mapper.Map<Users>(storedRegisterInfo);
        //        _context.Users.Add(newUser);
        //        _context.SaveChanges();
        //        _cache.Remove(otpKey);
        //        _cache.Remove(registerKey);
        //        return OperationResult.Success();
        //    }
        //    catch (Exception)
        //    {
        //        return OperationResult.Error();
        //    }
        //}

        //public async Task<string> SendOTP(string? phoneNumber)
        //{
        //    using var client = new HttpClient();
        //    string code = new Random().Next(100000, 999999).ToString();            
        //    _cache.Set(phoneNumber, code, TimeSpan.FromMinutes(2));
        //    await client.GetAsync($"http://localhost:5000/?code={code}");
        //    return code;
        //}

    }
}
