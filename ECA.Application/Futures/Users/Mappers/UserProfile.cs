using AutoMapper;
using ECA.Application.Futures.Users.Models;
using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Application.Futures.Users.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserAddress, UserAddressDto>()
            .ReverseMap();
        
        CreateMap<User, UserDto>()
            .ForMember(x=>x.Status,x=>x.MapFrom(v=>v.Status.Name))
            .ForMember(x=>x.StatusId,x=>x.MapFrom(v=>v.Status.Id))
            .ForMember(x=>x.Address,x=>x.MapFrom(v=>v.Address)).ReverseMap();
    }
}