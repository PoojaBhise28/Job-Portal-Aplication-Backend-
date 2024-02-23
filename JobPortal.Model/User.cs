using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Model
{
    [Table("Users")]
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class User : BaseEntity
    {
        //public User()
        //{
        //    PersonalInfo = new PersonalInfo(); // Initialize with default value
        //}
        //[Key]
        //public long Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation property for PersonalInfo
        public PersonalInfo PersonalInfo { get; set; }
    }
}
