using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FC.Entities;
using FC.Repositories;


namespace FC.Repositories
{

    public class SupplierRepository : IRepository<FC.Entities.FC_Supplier>
    {
        private FcEntities dbcontext;

        public void Add(FC_Supplier entity)
        {
            using (dbcontext = new FcEntities())
            {
                dbcontext.FC_Supplier.Add(entity);
                dbcontext.SaveChanges();
            }

        }

        public bool Delete(FC_Supplier entity)
        {
            if (dbcontext.FC_Supplier.Contains(entity))
            {
                dbcontext.FC_Supplier.Add(entity);
            }
            dbcontext.SaveChanges();
            return true;
        }

        public FC_Supplier Get(Expression<Func<FC_Supplier, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FC_Supplier> GetAll()
        {
            dbcontext = new FcEntities();

            var SupplierList = dbcontext.FC_Supplier.Where(c => c.IsDeleted == false);
            return SupplierList;

        }

        public bool Update(FC_Supplier entity)
        {
            throw new NotImplementedException();
        }
    }


}
