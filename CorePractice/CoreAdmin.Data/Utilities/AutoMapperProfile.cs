using AutoMapper;
using CoreAdmin.Domain.DataModels;
using CoreAdmin.Data.Entities;

namespace CoreAdmin.Data.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerEntity, Customer>();
            CreateMap<UserEntity, User>();
        }
    }
}
