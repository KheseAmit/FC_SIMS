using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public void SaveChanges(FC_Supplier entity)
        {
            using (dbcontext = new FcEntities())
            {
                dbcontext.FC_Supplier.AddOrUpdate(entity);
                dbcontext.SaveChanges();
            }
        }

        public FC_Supplier Get(int id)
        {
            using (var newdbcontext = new FcEntities())
            {
                return newdbcontext.FC_Supplier.FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<FC_Supplier> GetAll()
        {
            dbcontext = new FcEntities();

            var SupplierList = dbcontext.FC_Supplier.Where(c => c.IsDeleted == false);
            return SupplierList;

        }
    }
}
