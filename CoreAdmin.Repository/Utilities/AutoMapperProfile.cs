using AutoMapper;
using CoreAdmin.Domain.DataModels;
using CoreAdmin.Repository.Entities;

namespace CoreAdmin.Repository.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerEntity, Customer>();
        }
    }
}
