using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context=new ApplicationDbContext();
        string todaysDate = DateTime.Now.ToShortDateString();
        string currentDay = DateTime.Now.DayOfWeek.ToString();
        // GET: Employee
        public ActionResult Index(Employee employee,string todaysDate,string currentDay)
        {
            string userId = User.Identity.GetUserId();
            if(employee.Zip == null)
            {
                employee = _context.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            }
            //employee.ApplicationId = userId;
            //DateTime.Now.DayOfWeek;
            //var todaysDate = DateTime.Now;
            var customerInZip = _context.Customers.Where(c => c.Zip == employee.Zip && c.PickupDay==currentDay||c.Zip==employee.Zip && c.ExtraPickupDate==todaysDate).ToList();
            return View(customerInZip);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Confirm(int id)
        {
            var confirmPickupUpdate = _context.Customers.Where(c => c.ID == id).FirstOrDefault();
            confirmPickupUpdate.ConfirmPickup = true;
            confirmPickupUpdate.Balance += 1.50;
            _context.SaveChanges();
            return RedirectToAction("Index","Employee");
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                employee.ApplicationId = userId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                //var customerInZip = _context.Customers.Where(e=>e.Zip == employee.Zip).ToList();
                return RedirectToAction("Index",employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
