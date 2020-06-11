using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using my_vidly.Models;
using my_vidly.ViewModels;

namespace my_vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Customers
		//[Route("customers")]
		public ActionResult Index()
		{
			//use context + eager loading
			//var customers = _context.Customers.Include(c => c.MembershipType).ToList();
			return View();
		}

		// GET: Customers/Details/5
		public ActionResult Details(int id)
		{
			//FirstOrDefault is "Find" equivalence for IEnumberable
			var ret = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == id);
			if (ret == null)
				return Content("No Customer found.");
			return View(ret);
		}

		public ActionResult New()
		{
			var membershipType = _context.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel()
			{
				Customer = new Customer(),
				MembershipTypes = membershipType
			};
			return View("CustomerForm", viewModel);
		}

		/*
		 * Malicious user exploit:
		 * 1. Update another user's Data using ID. Solution: ??
		 * 2. Update unauthorized data field. Solution: use Dto or follow this example
		 */
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			//Server site validation
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel()
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel);
			}


			if (customer.Id == 0)
				_context.Customers.Add(customer); //Stage changes
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.BirthDay = customer.BirthDay;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			_context.SaveChanges(); //Execute changes

			return RedirectToAction("Index", "Customers");
		}

		/*
		// POST: Customers/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Customers/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Customers/Edit/5
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

		// GET: Customers/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Customers/Delete/5
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
		*/
		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customer == null) return HttpNotFound();
			var viewModel = new CustomerFormViewModel()
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			return View("CustomerForm", viewModel);
		}
	}
}
