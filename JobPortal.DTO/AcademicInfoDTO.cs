using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetAcademicInfoDTO(long Id, string InstitutionName, int StartYear, int EndYear, double Percentage, string Degree, long UserId);





    public record CreateAcademicInfoDTO(string InstitutionName, int StartYear, int EndYear, double Percentage, string Degree, long UserId);
    public record UpdateAcademicInfoDTO(long Id, string InstitutionName, int StartYear, int EndYear, double Percentage, string Degree, long UserId);
}
