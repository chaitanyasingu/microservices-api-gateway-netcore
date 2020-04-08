using Customer.Microservice.DatabaseContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customer.Microservice.Respository
{
    public class CustomerRepository<T> : Domain.Core.IRepository.IBaseCRUD<Models.Customer>
    {
        private readonly CustomerDbContext dbContext;

        public CustomerRepository()
        {
            if (dbContext == null)
                dbContext = new CustomerDbContext();
        }
        public CustomerRepository(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #region CRUD
        public int Add(Models.Customer item)
        {
            try
            {
                var NewItem = dbContext.Add(item);
                Save();
                return NewItem.Entity.CustomerId;
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
                var Prd = dbContext.Customers.AsQueryable().Where(x => x.CustomerId == ID).FirstOrDefault();
                dbContext.Customers.Remove(Prd);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Models.Customer> Get()
        {

            return dbContext.Customers
                .AsEnumerable();
        }

        public Models.Customer GetBy(int ID, string name = null)
        {
            return dbContext.Customers.AsQueryable().Where(
                x => x.CustomerId == ID || 
                (name != null && (x.FName.ToLower() == name.ToLower() || x.LName.ToLower() == name.ToLower()))).FirstOrDefault();
        }

        public bool Update(Models.Customer item)
        {
            try
            {
                dbContext.Customers.Update(item);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
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
    }
}
