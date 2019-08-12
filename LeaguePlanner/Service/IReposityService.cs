using LeaguePlanner.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePlanner.Service
{

    interface IReposityService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<IEnumerable<User>> GetUserByIdOrName(User user);

    }
}
