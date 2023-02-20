using OpenWork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Interfaces.Security
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
        public string GenerateToken(Worker worker);
    }
}
