﻿using Olympics2021.Models;
using Olympics2021.Models.ViewModels;
using Olympics2021.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Controllers
{
    public class AthletesController : Controller
    {
        private readonly AthletesIntegratedService _integratedService;
        private readonly AthletesDbService _athletesDbService;

        public AthletesController(AthletesIntegratedService integratedService, AthletesDbService athletesDbService)
        {
            _integratedService = integratedService;
            _athletesDbService = athletesDbService;
        }

        public IActionResult Index()
        {
            ParticipantsModel model = _integratedService.GetModelForIndex();

            return View(model);
        }

        public IActionResult Create()
        {
            ParticipantsModel model = _integratedService.GetModelForCreate();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(List<AthleteModel> athletes)
        {
            _athletesDbService.AddAthlete(athletes[0]);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ParticipantsModel model = _integratedService.GetModelForEdit(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(List<AthleteModel> athletes)
        {
            //_athletesDbService.AddAthlete(athletes[0]);

            return RedirectToAction("Index");
        }
    }
}
