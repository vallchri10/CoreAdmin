using AutoMapper;
using CorePractice.Data.DataSources;
using CorePractice.Domain.Models;

namespace CorePractice.Api
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
