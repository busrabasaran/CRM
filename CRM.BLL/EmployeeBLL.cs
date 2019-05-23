using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
    public class EmployeeBLL
    {
        Repository<Employees> repo = new Repository<Employees>();

        public Employees GetEmployee(string email)
        {
            return repo.Find(x => x.Email == email);
        }

        public List<Employees> GetEmployees()
        {
            return repo.List();
        }

        public void Update(Employees employees)
        {
            repo.Update(employees);
        }
    }
}
