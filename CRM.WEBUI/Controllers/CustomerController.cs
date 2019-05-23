using CRM.BLL;
using CRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.WEBUI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerBLL customerBLL = new CustomerBLL();
        NotesBLL notesBLL = new NotesBLL();
        LeadsBLL leadsBLL = new LeadsBLL();

        public void isRoles(Employees emp)
        {
            foreach (EmployeeRoles item in emp.EmployeeRoles)
            {
                if (item.Roles.RoleName == "Satış")
                {
                    ViewBag.MusteriGuncellerButon = "visible";
                    ViewBag.MusteriEkleButon = "hidden";
                    ViewBag.MusteriSilButon = "hidden";
                    ViewBag.LeadEkleButon = "visible";
                    ViewBag.LeadSilButon = "hidden";
                    ViewBag.NoteEkleButon = "hidden";
                    ViewBag.NoteSilButon = "hidden";
                }
                else if (item.Roles.RoleName == "Manager")
                {
                    ViewBag.MusteriGuncellerButon = "visible";
                    ViewBag.MusteriEkleButon = "hidden";
                    ViewBag.MusteriSilButon = "visible";
                    ViewBag.LeadEkleButon = "visible";
                    ViewBag.LeadSilButon = "hidden";
                    ViewBag.NoteEkleButon = "hidden";
                    ViewBag.NoteSilButon = "hidden";
                }
                else
                {
                    ViewBag.MusteriGuncellerButon = "visible";
                    ViewBag.MusteriEkleButon = "visible";
                    ViewBag.MusteriSilButon = "visible";
                    ViewBag.LeadEkleButon = "visible";
                    ViewBag.LeadSilButon = "visible";
                    ViewBag.NoteEkleButon = "visible";
                    ViewBag.NoteSilButon = "visible";
                }
            }
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customer = customerBLL.GetCustomers();

            Employees emp = Session["Login"] as Employees;
            isRoles(emp);

            return View(customer);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customers customer)
        {
            customerBLL.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            Customers customer = customerBLL.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customers customer)
        {
            Customers cust = customerBLL.GetCustomer(customer.CustomerID);
            cust.CustomerID = customer.CustomerID;
            cust.Name = customer.Name;
            cust.Surname = customer.Surname;
            cust.Email = customer.Email;
            cust.Phone = customer.Phone;
            cust.Company = customer.Company;
            cust.BirthDate = customer.BirthDate;
            cust.Address = customer.Address;
            cust.City = customer.City;

            customerBLL.UpdateCustomer(cust);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            Customers customer = customerBLL.GetCustomer(id);
            List<Notes> notes = notesBLL.GetNotes(id);
            foreach (Notes item in notes)
            {
                notesBLL.DeleteNote(item.NoteID);
            }
            List<Leads> leads = leadsBLL.GetLeads(id);
            foreach (Leads item in leads)
            {
                leadsBLL.DeleteLead(item.LeadID);
            }
            customerBLL.DeleteCustomers(customer);

            return RedirectToAction("Index");
        }

        public ActionResult ListNotes(int id)
        {
            Employees emp = Session["Login"] as Employees;
            isRoles(emp);

            Customers cust = customerBLL.GetCustomer(id);
            Session["Customer"] = cust;
            List<Notes> notlar = notesBLL.GetNotes(cust.CustomerID);
            return View(notlar);
        }
        public ActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNote(Notes note)
        {
            Employees emp = Session["Login"] as Employees;
            Customers cust = Session["Customer"] as Customers;
            note.EmployeeID = emp.EmployeeID;
            note.CustomerID = cust.CustomerID;
            note.Date = DateTime.Now;
            notesBLL.AddNote(note);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteNote(int id)
        {
            notesBLL.DeleteNote(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListLeads(int id)
        {
            Employees emp = Session["Login"] as Employees;
            isRoles(emp);

            Customers cust = customerBLL.GetCustomer(id);
            Session["Customer"] = cust;
            List<Leads> leadler = leadsBLL.GetLeads(cust.CustomerID);
            return View(leadler);
        }

        public ActionResult AddLead()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLead(Leads lead)
        {
            Employees emp = Session["Login"] as Employees;
            Customers cust = Session["Customer"] as Customers;
            lead.EmployeeID = emp.EmployeeID;
            lead.CustomerID = cust.CustomerID;
            lead.Date = DateTime.Now;
            leadsBLL.AddLead(lead);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteLead(int id)
        {
            leadsBLL.DeleteLead(id);
            return RedirectToAction("Index");
        }


    }
}