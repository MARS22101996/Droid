using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Enums;
using VTSClient.DAL.Infrastructure;
using VTSClient.DAL.Interfaces;

namespace VTSClient.BLL.Services
{
    public class ApiVacationService : IApiVacationService
    {
        private readonly IApiRepository _vacationRepository;
        //private readonly IMapper _mapper;

        public ApiVacationService(IApiRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
           // _mapper = mapper;
        }

        public async Task<IEnumerable<VacationDto>> GetVacationAsync()
        {
            var vacations = await _vacationRepository.GetAsync<Vacation>(UrlName.GetApiUrl());

            var vacationDtos = Mapper.Map<IEnumerable<VacationDto>>(vacations);

            return vacationDtos;
        }

		public async Task<IEnumerable<VacationDto>> FilterVacations(FilterEnum type)
		{
			var vacations = await _vacationRepository.GetAsync<Vacation>(UrlName.GetApiUrl());
			switch (type)
			{
				case FilterEnum.Closed:
					return Mapper.Map<IEnumerable<VacationDto>>(vacations.Where(x => x.VacationStatus == VacationStatus.Closed));

				case FilterEnum.Opened:
					return Mapper.Map<IEnumerable<VacationDto>>(vacations.Where(x => x.VacationStatus != VacationStatus.Closed));

				default:
					return Mapper.Map<IEnumerable<VacationDto>>(vacations);
			}
		}

		public async Task<VacationDto> GetVacationByIdAsync(Guid id)
        {
            var vacation = await _vacationRepository.GetByIdAsync<Vacation>(id, UrlName.GetApiUrl());

            var vacationDto = Mapper.Map<VacationDto>(vacation);

            return vacationDto;
        }

        public Task<bool> CreateVacationAsync(VacationDto entity)
        {
            var vacation = Mapper.Map<Vacation>(entity);

            return _vacationRepository.CreateAsync(vacation, UrlName.GetApiUrl());
        }

        public Task<bool> UpdateVacationAsync(VacationDto entity)
        {
            var vacation = Mapper.Map<Vacation>(entity);

            return _vacationRepository.UpdateAsync(vacation, UrlName.GetApiUrl());
        }

        public Task<bool> DeleteVacationByIdAsync(Guid id)
        {
            return _vacationRepository.DeleteAsync<Vacation>(id, UrlName.GetApiUrl());
        }

		public VacationDto GetExampleVacation()
		{
			var vacation = new VacationDto
			{
				VacationStatus = VacationStatus.Approved,
				Id = Guid.NewGuid(),
				VacationType = VacationType.Undefined,
				CreatedBy = "Ark",
				End = DateTime.UtcNow,
				Start = DateTime.UtcNow
			};

			return vacation;
		}
	}
}
