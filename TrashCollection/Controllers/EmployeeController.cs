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
       
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index(Employee employee)
        {
            string userId = User.Identity.GetUserId();
            if(employee.Zip == null)
            {
                employee = _context.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            }
            string todaysDate = DateTime.Now.ToShortDateString();
            string dayToDisplay = DateTime.Now.DayOfWeek.ToString();
            var customerInZip = _context.Customers.Where(c => c.Zip == employee.Zip && c.PickupDay==dayToDisplay||c.Zip==employee.Zip && c.ExtraPickupDate==todaysDate).ToList();
            return View(customerInZip);
        }
        public ActionResult IndexDay(string DayString)
        {
            string userId = User.Identity.GetUserId();
            var employee = _context.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            string dayToDisplay = DayString;
            var customerInZip = _context.Customers.Where(c => c.Zip == employee.Zip && c.PickupDay == dayToDisplay).ToList();
            ViewBag.dayToDisplay = dayToDisplay;
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
        public ActionResult ConfirmDayOnly(int id,string DayString)
        {
            var confirmPickupUpdate = _context.Customers.Where(c => c.ID == id).FirstOrDefault();
            confirmPickupUpdate.ConfirmPickup = true;
            confirmPickupUpdate.Balance += 1.50;
            _context.SaveChanges();
            string userId = User.Identity.GetUserId();
            var employee = _context.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            string dayToDisplay = DayString;
            var customerInZip = _context.Customers.Where(c => c.Zip == employee.Zip && c.PickupDay == dayToDisplay).ToList();
            ViewBag.dayToDisplay = dayToDisplay;
            return View(customerInZip);
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
