using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FC.Entities;


namespace FC.Repositories
{
    public class UserRepository:IUserRepository
    {
        private IPasswordHasher passwordHasher;
        private FcEntities dbcontext;

        public UserRepository()
        {
            passwordHasher = new PasswordHasher();
        }

        public bool IsValidUser(FC_Users fcUser,out int Id)
        {
            using (dbcontext = new FcEntities())
            {

                var objUser = dbcontext.FC_Users.FirstOrDefault(c => c.Name == fcUser.Name &&
                                                         c.IsAdmin == fcUser.IsAdmin);
                Id = objUser != null ? objUser.Id : 0;
                return objUser != null && passwordHasher.VerifyHashedPassword(fcUser.Password, objUser.Password,
                    (string.IsNullOrEmpty(objUser.PasswordSalt)
                        ? passwordHasher.GetRandomSalt()
                        : objUser.PasswordSalt));
            }
        }

         
    }
}
