using CRM.BLL;
using CRM.Entity;
using CRM.WEBUI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        EmployeeBLL employeeBLL = new EmployeeBLL();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employees emp)
        {
            Employees employee = employeeBLL.GetEmployee(emp.Email);
            if (employee != null)
            {
                if (employee.Password == emp.Password)
                {
                    Session["Login"] = employee;
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    return RedirectToAction("LoginHata");
                }
            }
            else
            {
                return RedirectToAction("LoginHata");
            }
        }

       
        public ActionResult Logout()
        {
            Session.Remove("Login");
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult LoginHata()
        {
            return View();
        }
    }
}