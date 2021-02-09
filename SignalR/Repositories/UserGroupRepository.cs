using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        public UserGroupRepository()
        {
        }

        public async Task<ICollection> GetUserGroups(int userId)
        {
            return await _context.Users.Where(u => u.userId == userId).Select(u => u.userGroups);
        }
    }
}
