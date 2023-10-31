using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Goldan_Maria_EB_lab2.Data;
using Goldan_Maria_EB_lab2.Models;
using LibraryModel.Models;

namespace Goldan_Maria_EB_lab2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly LibraryContext _context;
        private string _baseUrl = "http://localhost:5108/api/Customers";
        private string _baseUrlCities = "http://localhost:5108/api/Cities";

        public CustomersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
            {
                var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(await response.Content.ReadAsStringAsync());
                return View(customers);
            }

            return NotFound();
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/dto/{id.Value}");

            if (response.IsSuccessStatusCode)
            {
                var customer = JsonConvert.DeserializeObject<CustomerDTO>(await response.Content.ReadAsStringAsync());
                return View(customer);
            }

            return NotFound();
        }

        // GET: Customers/Create
        public async Task<IActionResult> Create()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrlCities);

            if (response.IsSuccessStatusCode)
            {
                var cities = JsonConvert.DeserializeObject<List<City>>(await response.Content.ReadAsStringAsync());
                ViewData["CityID"] = new SelectList(cities, "ID", "CityName");
            }

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Adress,CityID,BirthDate")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            
            try
            {
                var client = new HttpClient();
                string json = JsonConvert.SerializeObject(customer);
                var response = await client.PostAsync(_baseUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id.Value}");

            if (response.IsSuccessStatusCode)
            {
                var customer = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
                response = await client.GetAsync(_baseUrlCities);

                if (response.IsSuccessStatusCode)
                {
                    var cities = JsonConvert.DeserializeObject<List<City>>(await response.Content.ReadAsStringAsync());
                    ViewData["CityID"] = new SelectList(cities, "ID", "CityName");
                }

                return View(customer);
            }

            return new NotFoundResult();
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Adress,CityID,BirthDate")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);

            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(customer);
            var response = await client.PutAsync($"{_baseUrl}/{customer.ID}",new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/dto/{id.Value}");

            if (response.IsSuccessStatusCode)
            {
                var customer = JsonConvert.DeserializeObject<CustomerDTO>(await response.Content.ReadAsStringAsync());
                return View(customer);
            }

            return new NotFoundResult();
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([Bind("ID")] CustomerDTO customer)
        {
            try
            {
                var client = new HttpClient();

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{customer.ID}")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to delete record: {ex.Message}");
            }

            return View(customer);
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
