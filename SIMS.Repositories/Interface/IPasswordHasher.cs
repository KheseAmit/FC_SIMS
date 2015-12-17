using FC.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace FC.Repositories
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, string salt);
        string GetRandomSalt(int size = 12);
        bool VerifyHashedPassword(string enteredPassword, string storedHash, string storedSalt);
    }
}