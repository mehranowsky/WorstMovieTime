using AutoMapper;
using ModelLayer.Context;
using ModelLayer.Models;
using ModelLayer.Models.ViewModels;

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

        public bool Register(RegisterViewModel registerInfo)
        {
            try
            {
                var existingUser = _context.Users.FirstOrDefault(e => e.PhoneNumber == registerInfo.PhoneNumber);
                if (existingUser != null)
                {
                    return false;
                }

                var newUser = _mapper.Map<Users>(registerInfo);
                newUser.Role = Users.UserRole.User;
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Login(LoginViewModel loginInfo)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(e => e.PhoneNumber == loginInfo.PhoneNumber);
                if (user != null)
                {
                    if (user.Password == loginInfo.Password)
                    {
                        return true;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string SendOTP()
        {            
            string code = new Random().Next(100000, 1000000).ToString();
            return code;
        }

    }
}
