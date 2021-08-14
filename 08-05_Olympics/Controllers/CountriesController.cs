using Olympics2021.Models;
using Olympics2021.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Controllers
{
    public class CountriesController : Controller
    {
        private readonly CountriesDbService _dbService;

        public CountriesController(CountriesDbService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            List<CountryModel> countries = _dbService.GetCountries();

            return View(countries);
        }

        public IActionResult Create()
        {
            CountryModel newCountry = new();

            return View(newCountry);
        }

        [HttpPost]
        public IActionResult Create(CountryModel country)
        {
            _dbService.AddCountry(country);

            return RedirectToAction("Index");
        }
    }
}
