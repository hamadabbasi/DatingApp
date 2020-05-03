using System.Linq;
using AutoMapper;
using DatingApp.api.Dtos;
using DatingApp.api.Models;

namespace DatingApp.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDtos>()
            .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom( src => src.Photos.FirstOrDefault(x => x.IsMain).Url ))
            .ForMember(dest => dest.Age, opt =>
            opt.MapFrom( src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDtos>()
            .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom( src => src.Photos.FirstOrDefault(x => x.IsMain).Url ))
            .ForMember(dest => dest.Age, opt =>
            opt.MapFrom( src => src.DateOfBirth.CalculateAge()));;
            CreateMap<Photo, PhotosForDetailedDtos>();
        }
    }
}