
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
    public class EmploymentInfoService : IEmploymentInfoService
    {
        private readonly IEmploymentInfoRepository _employmentInfoRepository; 
        public EmploymentInfoService(IEmploymentInfoRepository employmentInfoRepository)
        {
            _employmentInfoRepository = employmentInfoRepository;
        }

        public async Task<GetEmploymentInfoDTO> CreateEmploymentInfoAsync(CreateEmploymentInfoDTO employmentInfoDTO)
        {
            try
            {
                var employmentInfo = new EmploymentInfo()
                {
                    UpdatedUserId = employmentInfoDTO.UserId,
                    CreatedUserId = employmentInfoDTO.UserId,
                    CurrentCTC = employmentInfoDTO.CurrentCTC,
                    NoticePeriod = employmentInfoDTO.NoticePeriod,
                    ExpectedCTC = employmentInfoDTO.ExpectedCTC,
                    UserId = employmentInfoDTO.UserId,
                  

                };

                var newEmploymentInfo = await _employmentInfoRepository.CreateAsync(employmentInfo);


                var newEmploymentInfoDTO = new GetEmploymentInfoDTO(
                    newEmploymentInfo.Id,
                   newEmploymentInfo.CurrentCTC,
                   newEmploymentInfo.NoticePeriod,
                    newEmploymentInfo.ExpectedCTC,
                    newEmploymentInfo.UserId);

                return newEmploymentInfoDTO;
            }
            catch (Exception)
            {

                throw;
            }


            
        }

        public async Task<bool> DeleteEmploymentInfoAsync(long Id)
        {
            try
            {
                var employmentInfo = await _employmentInfoRepository.GetByIdAsync(Id);

                if (employmentInfo == null)
                {
                    throw new Exception($"Then employment Info with Id {Id} not found for delete");
                }

                return await _employmentInfoRepository.DeleteAsync(employmentInfo);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<GetEmploymentInfoDTO>> GetAllEmploymentInfosAsync()
        {
            try
            {
                var employmentInfos = await _employmentInfoRepository.GetAllAsync();

                var employmentInfosDto = employmentInfos.Select(info => (new GetEmploymentInfoDTO(
                            info.Id,
                            info.CurrentCTC,
                            info.NoticePeriod,
                            info.ExpectedCTC,
                            info.UserId)));

                return employmentInfosDto;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<GetEmploymentInfoDTO> GetEmploymentInfoByIdAsync(long Id)
        {

            try
            {
                var employmentInfo = await _employmentInfoRepository.GetByIdAsync(Id);

                var employmentInfoDto = new GetEmploymentInfoDTO(
                                employmentInfo.Id,
                            employmentInfo.CurrentCTC,
                            employmentInfo.NoticePeriod,
                            employmentInfo.ExpectedCTC,
                            employmentInfo.UserId);

                return employmentInfoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetEmploymentInfoDTO>> GetEmploymentInfosByUserIdAsync(long userId)
        {
            try
            {
                // Define the expression to filter academic infos by userId
                Expression<Func<EmploymentInfo, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var academicInfos = await _employmentInfoRepository.GetByConditionAsync(expression);

                // Convert academic infos to DTOs
                var academicInfoDTOs = academicInfos.Select(info => new GetEmploymentInfoDTO(info.Id,
                            info.CurrentCTC,
                            info.NoticePeriod,
                            info.ExpectedCTC,
                            info.UserId));


                return academicInfoDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetEmploymentInfoDTO> UpdateEmploymentInfoAsync(long Id, UpdateEmploymentInfoDTO employmentDetailDTO)
        {
            try
            {
                var employmentInfo = await _employmentInfoRepository.GetByIdAsync(Id);
                if (employmentInfo == null)
                {  // Throw custom exception indicating user not found
                    throw new Exception($"Employment info with ID {Id} not found for update.");
                }


                employmentInfo.UpdatedUserId = employmentDetailDTO.UserId;
                employmentInfo.CurrentCTC = employmentDetailDTO.CurrentCTC;
                employmentInfo.NoticePeriod = employmentDetailDTO.NoticePeriod;
               employmentInfo. ExpectedCTC = employmentDetailDTO.ExpectedCTC;
                employmentInfo.UserId = employmentDetailDTO.UserId;
                employmentInfo.UpdatedUserId = employmentDetailDTO.UserId;
                employmentInfo.UpdatedDate = DateTime.Now;


                var updatedEmploymentInfo = await _employmentInfoRepository.UpdateAsync(employmentInfo);

                var employmentInfoDto = new GetEmploymentInfoDTO(
                                  updatedEmploymentInfo.Id,
                              updatedEmploymentInfo.CurrentCTC,
                              updatedEmploymentInfo.NoticePeriod,
                              updatedEmploymentInfo.ExpectedCTC,
                              updatedEmploymentInfo.UserId);
                return employmentInfoDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
