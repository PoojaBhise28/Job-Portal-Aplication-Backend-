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
    public class AddressInfoService: IAddressInfoService
    {
        private readonly IAddressInfoRepository   _addressInfoRepository;

        public AddressInfoService(IAddressInfoRepository addressInfoRepository)
        {
            _addressInfoRepository = addressInfoRepository;
        }

        public async Task<GetAddressInfoDTO> CreateAddressInfoAsync(CreateAddressInfoDTO addressInfoDTO)
        {
            try
            {
                var addressInfo = new AddressInfo
                {
                    Address = addressInfoDTO.Address,
                    City = addressInfoDTO.City,
                    StateId = addressInfoDTO.StateId,
                    CountryId = addressInfoDTO.CountryId,
                    UserId = addressInfoDTO.UserId
                };

                var newAddressInfo = await _addressInfoRepository.CreateAsync(addressInfo);

                return MapToGetAddressInfoDTO(newAddressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating address info: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAddressInfoAsync(long Id)
        {
            try
            {
                var addressInfo = await _addressInfoRepository.GetByIdAsync(Id);
                if (addressInfo == null)
                {
                    throw new Exception($"Address info with ID {Id} not found for delete.");
                }

                return await _addressInfoRepository.DeleteAsync(addressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting address info: {ex.Message}");
            }
        }

        public async Task<IEnumerable<GetAddressInfoDTO>> GetAllAddressInfosAsync()
        {
            try
            {
                var addressInfos = await _addressInfoRepository.GetAllAsync();

                return addressInfos.Select(MapToGetAddressInfoDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving address infos: {ex.Message}");
            }
        }

        public async Task<GetAddressInfoDTO> GetAddressInfoByIdAsync(long Id)
        {
            try
            {
                var addressInfo = await _addressInfoRepository.GetByIdAsync(Id);
                if (addressInfo == null)
                {
                    return null;
                }

                return MapToGetAddressInfoDTO(addressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving address info: {ex.Message}");
            }
        }

        public async Task<GetAddressInfoDTO> UpdateAddressInfoAsync(long Id, UpdateAddressInfoDTO addressInfoDTO)
        {
            try
            {
                var addressInfo = await _addressInfoRepository.GetByIdAsync(Id);
                if (addressInfo == null)
                {
                    throw new Exception($"Address info with ID {Id} not found for update.");
                }

                addressInfo.Address = addressInfoDTO.Address;
                addressInfo.City = addressInfoDTO.City;
                addressInfo.StateId = addressInfoDTO.StateId;
                addressInfo.CountryId = addressInfoDTO.CountryId;
                addressInfo.UserId = addressInfoDTO.UserId;

                var updatedAddressInfo = await _addressInfoRepository.UpdateAsync(addressInfo);

                return MapToGetAddressInfoDTO(updatedAddressInfo);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating address info: {ex.Message}");
            }
        }
        public async Task<IEnumerable<GetAddressInfoDTO>> GetAddressInfosByUserIdAsync(long userId)
        {
            try
            {
                // Define the expression to filter academic infos by userId
                Expression<Func<AddressInfo, bool>> expression = a => a.UserId == userId;

                // Call the repository method to get academic infos based on the expression
                var addressInfos = await _addressInfoRepository.GetByConditionAsync(expression);

                // Convert academic infos to DTOs
                var aaddressInfoDTOs = addressInfos.Select(MapToGetAddressInfoDTO); ;


                return aaddressInfoDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private GetAddressInfoDTO MapToGetAddressInfoDTO(AddressInfo addressInfo)
        {
            return new GetAddressInfoDTO
            {
                Id = addressInfo.Id,
                Address = addressInfo.Address,
                City = addressInfo.City,
                StateId = addressInfo.StateId,
                CountryId = addressInfo.CountryId,
                UserId = addressInfo.UserId
            };
        }

       
    }
}
