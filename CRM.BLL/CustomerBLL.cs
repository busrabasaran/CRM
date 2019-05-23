using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
    public class CustomerBLL
    {
        Repository<Customers> repo = new Repository<Customers>();
        

        public List<Customers> GetCustomers()
        {
            return repo.List();
        }

        public Customers GetCustomer(int id)
        {
            return repo.Find(x => x.CustomerID == id);
        }

        public void AddCustomer(Customers cust)
        {
            repo.Insert(cust);
        }

        public void UpdateCustomer(Customers customers)
        {
            repo.Update(customers);
        }

        public void DeleteCustomers(Customers customer)
        {
            repo.Delete(customer);
        }

    }
}
