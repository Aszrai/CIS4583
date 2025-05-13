using CIS4583.IRepository;
using CIS4583.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Customer> customers = _repo.Customer_SelectList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _repo.Customer_Select(new Customer { CustomerId = id });
            if (customer == null) return NotFound();
            return View(customer);
        }

        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool creationSuccess = _repo.Customer_Insert(customer);
                if (creationSuccess)
                    return RedirectToAction("Index", "Customer");

                ModelState.AddModelError("", "Unable to create customer.");
            }

            return View(customer);
        }

        [HttpPost, ActionName("CreateConfirmed"), ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool creationSuccess = _repo.Customer_Insert(customer);

                if (creationSuccess)
                {
                    return RedirectToAction("Index", "Customer");
                }

                ModelState.AddModelError("", "Unable to create customer.");
            }

            return View("CreateConfirmation", customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _repo.Customer_Select(new Customer { CustomerId = id });
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId) return BadRequest();

            if (ModelState.IsValid)
            {
                if (_repo.Customer_Update(customer))
                    return RedirectToAction("Index", "Customer");

                ModelState.AddModelError("", "Unable to update customer.");
            }

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _repo.Customer_Select(new Customer { CustomerId = id });
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ActionName("DeleteConfirmed"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool deletionSuccess = _repo.Customer_Delete(new Customer { CustomerId = id });

            if (deletionSuccess)
            {
                var customers = _repo.Customer_SelectList();
                return View("customer");
            }

            return RedirectToAction("Index", "Customer");
        }
    }
}
