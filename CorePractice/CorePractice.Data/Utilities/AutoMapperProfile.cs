using AutoMapper;
using CorePractice.Domain.DataModels;
using CorePractice.Data.Entities;

namespace CorePractice.Data.Utilities
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
