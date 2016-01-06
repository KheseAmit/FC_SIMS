using System.Data.Entity.Migrations;
using FC.Entities;
using FC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Repositories
{
    public class ProductRepository : IRepository<FC.Entities.FC_Product>
    {
        private FcEntities dbcontext;

        public void SaveChanges(FC_Product entity)
        {
            using (dbcontext = new FcEntities())
            {
                dbcontext.FC_Product.AddOrUpdate(entity);
                dbcontext.SaveChanges();
            }
        }

        public FC_Product Get(int id)
        {
            using (var newdbcontext = new FcEntities())
            {
                return newdbcontext.FC_Product.FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<FC_Product> GetAll()
        {
            dbcontext = new FcEntities();
            var productList = dbcontext.FC_Product.Where(c => c.IsDeleted == false);
            return productList;

        }

         
    }
}
