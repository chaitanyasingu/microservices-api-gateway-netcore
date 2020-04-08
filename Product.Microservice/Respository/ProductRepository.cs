using Product.Microservice.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Domain.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Microservice.Respository
{
    public class ProductRepository<T> : IBaseCRUD<Models.Product>
    {
        private readonly ProductDbContext dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(Models.Product item)
        {
            try
            {
                var NewItem = dbContext.Add(item);
                Save();
                return NewItem.Entity.ProductId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteByID(int ID)
        {
            try
            {
                var Prd = dbContext.Products.AsQueryable().Where(x => x.ProductId == ID).FirstOrDefault();
                dbContext.Products.Remove(Prd);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Models.Product> Get()
        {

            return dbContext.Products
                .Include(ptype => ptype.ProductType)
                .AsEnumerable();
        }

        public Models.Product GetBy(int ID, string name = null)
        {
            return dbContext.Products.AsQueryable().Where(x => x.ProductId == ID || (name != null && x.ProductName == name )).FirstOrDefault();
        }

        public bool Save()
        {
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ep)
            { 
                return false;
            }
        }

        public bool Update(Models.Product item)
        {
            try
            {
                dbContext.Products.Update(item);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
