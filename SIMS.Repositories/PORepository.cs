using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FC.Entities;
using FC.Repositories;
using System.Data.Entity.Migrations;

namespace FC.Repositories
{
    public class PORepository : IRepository<FC.Entities.FC_PurchaseOrder>
    {
        private FcEntities dbcontext;

        public void SaveChanges(FC_PurchaseOrder entity)
        {
            using (dbcontext = new FcEntities())
            {
                dbcontext.FC_PurchaseOrder.AddOrUpdate(entity);
                dbcontext.SaveChanges();
            }
        }



        public FC_PurchaseOrder Get(int id)
        {
            using (var newdbcontext = new FcEntities())
            {
                return newdbcontext.FC_PurchaseOrder.FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<FC_PurchaseOrder> GetAll()
        {
            dbcontext = new FcEntities();
            var productList = dbcontext.FC_PurchaseOrder.Where(c => c.IsCanceled == false);
            return productList;

        }
    }


    public class POproductRepository : IRepository<FC.Entities.FC_PurchaseOrderProducts>
    {
        private FcEntities dbcontext;

        public void SaveChanges(FC_PurchaseOrderProducts entity)
        {
            using (dbcontext = new FcEntities())
            {
                dbcontext.FC_PurchaseOrderProducts.AddOrUpdate(entity);
                dbcontext.SaveChanges();
            }
        }

        public FC_PurchaseOrderProducts Get(int id)
        {
            using (var newdbcontext = new FcEntities())
            {
                return newdbcontext.FC_PurchaseOrderProducts.FirstOrDefault(c => c.PurchaseOrderProductId == id);
            }
        }

        public IEnumerable<FC_PurchaseOrderProducts> GetAll()
        {
            dbcontext = new FcEntities();
            var productList = dbcontext.FC_PurchaseOrderProducts;
            return productList;

        }
    }
}
