using FC.Entities;
using FC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Repositories
{
   public class ManufactureRepository : IRepository<FC.Entities.FC_Manufacture>
   {
       private FcEntities dbcontext;
        public void SaveChanges(FC.Entities.FC_Manufacture entity)
        {
            throw new NotImplementedException();
        }

        public FC.Entities.FC_Manufacture Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FC.Entities.FC_Manufacture> GetAll()
        {
            dbcontext = new FcEntities();
            var ManufactureList = dbcontext.FC_Manufacture.Where(c => c.IsDeleted == false);
            return ManufactureList.OrderBy(c => c.Name);

        }
    }
}
