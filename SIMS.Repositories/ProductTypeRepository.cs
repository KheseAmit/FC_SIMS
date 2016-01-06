using System;
using System.Collections.Generic;
using System.Linq;
using FC.Entities;

namespace FC.Repositories
{
    public class ProductTypeRepository : IRepository<FC.Entities.FC_ProductType>
    {
        private FcEntities dbcontext;
        public void SaveChanges(FC.Entities.FC_ProductType entity)
        {
            throw new NotImplementedException();
        }

        public FC.Entities.FC_ProductType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FC.Entities.FC_ProductType> GetAll()
        {
            dbcontext = new FcEntities();
            var ProductTypeList = dbcontext.FC_ProductType.Where(c => c.IsDeleted == false);
            return ProductTypeList.OrderBy(c => c.Name);

        }
    }
}