using JobPortal.Data;
using JobPortal.IRepositories;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(JobPortalDbContext context) : base(context)
        {
        }
        // Additional methods specific to User entity can be added here
    }
}
