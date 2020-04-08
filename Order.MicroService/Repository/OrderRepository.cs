using Domain.Core.IRepository;
using Order.MicroService.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.MicroService.Repository
{
    public class OrderRepository<T> : IBaseCRUD<Models.Order>
    {
        private readonly OrderDbContext dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(Models.Order item)
        {
            try
            {
                dbContext.Add(item);
                Save();
                return item.OrderId;
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
                var Prd = dbContext.Orders
                    .Include(p => p.Products)
                    .AsQueryable().Where(x => x.OrderId == ID).FirstOrDefault();
                dbContext.Orders.Remove(Prd);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Models.Order> Get()
        {
            return dbContext.Orders
                .Include(order => order.Products)
                .Include(ptype => ptype.PaymentType)
                .AsEnumerable();
        }

        public Models.Order GetBy(int ID, string name = null)
        {
            return dbContext.Orders.AsQueryable().Where(x => x.OrderId == ID).FirstOrDefault();
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

        public bool Update(Models.Order item)
        {
            try
            {
                dbContext.Orders.Update(item);
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
