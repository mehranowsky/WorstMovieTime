using AutoMapper;
using ModelLayer.Models;
using ModelLayer.Models.ViewModels;

namespace WorstMovieTime.Utilities
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile() {
            CreateMap<RegisterViewModel, Users>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<LoginViewModel, Users>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
