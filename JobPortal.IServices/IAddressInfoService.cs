using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IAddressInfoService
    {
        Task<GetAddressInfoDTO> CreateAddressInfoAsync(CreateAddressInfoDTO addressInfoDTO);
        Task<bool> DeleteAddressInfoAsync(long Id);
        Task<IEnumerable<GetAddressInfoDTO>> GetAllAddressInfosAsync();
        Task<GetAddressInfoDTO> GetAddressInfoByIdAsync(long Id);
        Task<GetAddressInfoDTO> UpdateAddressInfoAsync(long Id, UpdateAddressInfoDTO addressInfoDTO);

        Task<IEnumerable<GetAddressInfoDTO>> GetAddressInfosByUserIdAsync(long userId);
    }
}
