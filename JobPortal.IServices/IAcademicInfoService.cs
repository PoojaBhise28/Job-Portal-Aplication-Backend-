using JobPortal.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IAcademicInfoService
    {
        Task<GetAcademicInfoDTO> CreateAcademicInfoAsync(CreateAcademicInfoDTO academicInfoDTO);
        Task<bool> DeleteAcademicInfoAsync(long Id);
        Task<IEnumerable<GetAcademicInfoDTO>> GetAllAcademicInfosAsync();
        Task<GetAcademicInfoDTO> GetAcademicInfoByIdAsync(long Id);
        Task<GetAcademicInfoDTO> UpdateAcademicInfoAsync(long Id,UpdateAcademicInfoDTO academicInfoDTO);
        Task<IEnumerable<GetAcademicInfoDTO>> GetAcademicInfosByUserIdAsync(long userId);
    }
}
