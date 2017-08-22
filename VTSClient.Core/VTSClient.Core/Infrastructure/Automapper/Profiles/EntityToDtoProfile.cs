using AutoMapper;
using VTSClient.BLL.Dto;
using VTSClient.Core.Models;
using VTSClient.DAL.Entities;

namespace VTSClient.Core.Infrastructure.Automapper.Profiles
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Vacation, VacationDto>();

			CreateMap<User, LoginDto>();

			CreateMap<VacationCoreModel, VacationDto>();
		}
    }
}
