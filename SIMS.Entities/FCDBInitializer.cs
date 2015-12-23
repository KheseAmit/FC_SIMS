using FC.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Entities
{
    public class FCDBInitializer<T> : CreateDatabaseIfNotExists<FcEntities>
    {

        protected override void Seed(FC.Entities.FcEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            IList<FC_Users> defaultStandards = new List<FC_Users>();

            defaultStandards.Add(new FC_Users() { Name = "fcadmin", Password = "Password@123" });

            foreach (FC_Users user in defaultStandards)
                context.FC_Users.Add(user);

            base.Seed(context);


        }
    }
}
