using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();//put this in a constructor to prevent memory leak
        // GET: Customer
        public ActionResult Index(Customer customer)
        {
            string userId = User.Identity.GetUserId();
            if (customer.Zip == null)
            {
                customer = _context.Customers.Where(e => e.ApplicationId == userId).FirstOrDefault();
            }
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                string userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index",customer);
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult ChangePickup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePickup(Customer customer)
        {
            string userId = User.Identity.GetUserId();
            customer.ApplicationId = userId;
            var customerToChange = _context.Customers.Where(e => e.ApplicationId == userId).FirstOrDefault();
            customerToChange.PickupDay = customer.PickupDay;
            _context.SaveChanges();
            return RedirectToAction("Index", customerToChange);
        }
        public ActionResult SetSpecialPickup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetSpecialPickup(Customer customer)
        {
            string userId = User.Identity.GetUserId();
            customer.ApplicationId = userId;
            var customerToChange = _context.Customers.Where(e => e.ApplicationId == userId).FirstOrDefault();
            customerToChange.ExtraPickupDate = customer.ExtraPickupDate;
            _context.SaveChanges();
            return RedirectToAction("Index", customerToChange);
        }
        public ActionResult ChangeSuspend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeSuspend(Customer customer)
        {
            string userId = User.Identity.GetUserId();
            customer.ApplicationId = userId;
            var customerToChange = _context.Customers.Where(e => e.ApplicationId == userId).FirstOrDefault();
            customerToChange.SuspendStart = customer.SuspendStart;
            customerToChange.SuspendEnd = customer.SuspendEnd;
            _context.SaveChanges();
            return RedirectToAction("Index", customerToChange);
        }
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
