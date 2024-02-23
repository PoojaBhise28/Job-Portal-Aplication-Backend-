using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO
{
    public record GetAddressInfoDTO
    {
        public long Id { get; set; }
        public string Address { get; init; }
        public string City { get; init; }
        public long StateId { get; init; }
        public long CountryId { get; init; }
        public long UserId { get; init; }
       
    }
    public record CreateAddressInfoDTO
    {
     
        public string Address { get; init; }
        public string City { get; init; }
        public long StateId { get; init; }
        public long CountryId { get; init; }
        public long UserId { get; init; }

    }
    public record UpdateAddressInfoDTO
    {
        public long Id { get; set; }
        public string Address { get; init; }
        public string City { get; init; }
        public long StateId { get; init; }
        public long CountryId { get; init; }
        public long UserId { get; init; }

    }
}
