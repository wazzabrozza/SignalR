using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Repositories
{
    interface IUserGroupRepository
    {
        Task<ICollection> GetUserGroups(int userId);
    }
}
