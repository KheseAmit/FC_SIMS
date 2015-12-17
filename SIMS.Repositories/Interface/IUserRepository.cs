using FC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FC.Repositories
{
    public interface IUserRepository
    {
        bool IsValidUser(FC_Users fcUser);
    }
}

  
