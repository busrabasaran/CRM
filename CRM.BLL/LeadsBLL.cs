using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
    public class LeadsBLL
    {
        Repository<Leads> repo = new Repository<Leads>();


        public List<Leads> GetLeads(int id)
        {
            return repo.List(x => x.CustomerID == id);
        }

        public Leads GetLead(int id)
        {
            return repo.Find(x => x.CustomerID == id);
        }

        public void AddLead(Leads lead)
        {
            repo.Insert(lead);
        }

        public void UpdateLead(Leads leads)
        {
            repo.Update(leads);
        }

        public void DeleteLead(int id)
        {
            Leads lead = repo.Find(x => x.LeadID == id);
            repo.Delete(lead);
        }
    }
}
