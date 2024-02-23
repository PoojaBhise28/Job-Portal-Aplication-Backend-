using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class ExperienceInfoService : IExperienceInfoService
    {
        private readonly IExperienceInfoRepository _experienceInfoRepository;

        public ExperienceInfoService(IExperienceInfoRepository experienceInfoRepository)
        {
            _experienceInfoRepository = experienceInfoRepository;
        }

        public async Task<GetExperienceInfoDTO> CreateExperienceInfoAsync(CreateExperienceInfoDTO experienceDTO)
        {
            try
            {
                var experience = new ExperienceInfo
                {
                    CompanyName = experienceDTO.CompanyName,
                    StartYear = experienceDTO.StartYear,
                    EndYear = experienceDTO.EndYear,
                    DesignationId = experienceDTO.DesignationId,
                    UserId = experienceDTO.UserId
                };

                var newExperience = await _experienceInfoRepository.CreateAsync(experience);

                var newExperiance = new GetExperienceInfoDTO(newExperience.Id, newExperience.CompanyName, newExperience.StartYear, newExperience.EndYear, newExperience.DesignationId, newExperience.UserId);
               
                return newExperiance;
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteExperienceInfoAsync(long Id)
        {
            try
            {
                var experience = await _experienceInfoRepository.GetByIdAsync(Id);
                if (experience == null)
                {
                    throw new Exception($"Experience with ID {Id} not found.");
                }
                return await _experienceInfoRepository.DeleteAsync(experience);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetExperienceInfoDTO>> GetAllExperienceInfosAsync()
        {
            try
            {
                var experiences = await _experienceInfoRepository.GetAllAsync();
                var experiencesDto =  experiences.Select(e => new GetExperienceInfoDTO(e.Id, e.CompanyName, e.StartYear, e.EndYear, e.DesignationId, e.UserId)).ToList();

                return experiencesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetExperienceInfoDTO> GetExperienceInfoByIdAsync(long Id)
        {
            try
            {
                var experience = await _experienceInfoRepository.GetByIdAsync(Id);
                if (experience == null)
                {
                    throw new Exception($"Experience with ID {Id} not found.");
                }
                var experienceDto = new GetExperienceInfoDTO(experience.Id, experience.CompanyName, experience.StartYear, experience.EndYear, experience.DesignationId, experience.UserId);

                return experienceDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetExperienceInfoDTO>> GetExperienceInfosByUserIdAsync(long userId)
        {
            try
            {
                // Define the expression to filter academic infos by userId
                Expression<Func<ExperienceInfo, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var experienceInfos = await _experienceInfoRepository.GetByConditionAsync(expression);

                // Convert academic infos to DTOs
                var experienceInfoDTOs = experienceInfos.Select(e => new GetExperienceInfoDTO(e.Id, e.CompanyName, e.StartYear, e.EndYear, e.DesignationId, e.UserId));


                return experienceInfoDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetExperienceInfoDTO> UpdateExperienceInfoAsync(long Id, UpdateExperienceInfoDTO experienceDTO)
        {
            try
            {
                var existingExperience = await _experienceInfoRepository.GetByIdAsync(Id);
                if (existingExperience == null)
                {
                    throw new Exception($"Experience with ID {Id} not found.");
                }

                // Update existingExperience with properties from experienceDTO
                existingExperience.CompanyName = experienceDTO.CompanyName;
                existingExperience.StartYear = experienceDTO.StartYear;
                existingExperience.EndYear = experienceDTO.EndYear;
                existingExperience.DesignationId = experienceDTO.DesignationId;
                existingExperience.UserId = experienceDTO.UserId;

                // Save changes to database
                var updatedExperience = await _experienceInfoRepository.UpdateAsync(existingExperience);

              

              var updatedExperienceDto =  new GetExperienceInfoDTO(updatedExperience.Id, updatedExperience.CompanyName, updatedExperience.StartYear, updatedExperience.EndYear, updatedExperience.DesignationId, updatedExperience.UserId);


              
                return updatedExperienceDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
