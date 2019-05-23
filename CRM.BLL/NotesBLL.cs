using CRM.DAL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
    public class NotesBLL
    {
        Repository<Notes> repo = new Repository<Notes>();
        DataContext db = new DataContext();

        public List<Notes> GetNotes(int id)
        {
            return repo.List(x => x.CustomerID == id);
        }

        public Notes GetNote(int id)
        {
            return repo.Find(x => x.CustomerID == id);
        }

        public void AddNote(Notes not)
        {
            repo.Insert(not);
        }

        public void UpdateNote(Notes nots)
        {
            repo.Update(nots);
        }

        public void DeleteNote(int id)
        {
            Notes note = repo.Find(x => x.NoteID == id);
            repo.Delete(note);
        }
    }
}
