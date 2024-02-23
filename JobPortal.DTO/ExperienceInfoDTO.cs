using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetExperienceInfoDTO(long Id, string CompanyName, int StartYear, int EndYear,long DesignationId, long UserId);
    public record CreateExperienceInfoDTO( string CompanyName, int StartYear, int EndYear, long DesignationId, long UserId);
    public record UpdateExperienceInfoDTO(long Id, string CompanyName, int StartYear, int EndYear, long DesignationId, long UserId);

   
}
