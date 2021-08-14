﻿using Olympics2021.Models;
using Olympics2021.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Services
{
    public class AthletesIntegratedService
    {
        private readonly SqlConnection _connection;
        private readonly AthletesDbService _athletesDbService;
        private readonly CountriesDbService _countriesDbService;
        private readonly SportsDbService _sportsDbService;

        public AthletesIntegratedService(SqlConnection connection,
                                         AthletesDbService athletesDbService,
                                         CountriesDbService countriesDbService,
                                         SportsDbService sportsDbService)
        {
            _connection = connection;
            _athletesDbService = athletesDbService;
            _countriesDbService = countriesDbService;
            _sportsDbService = sportsDbService;
        }

        public ParticipantsModel GetModelForIndex()
        {
            ParticipantsModel model = new();
            model.Athletes = _athletesDbService.GetAthletes();
            model.Countries = _countriesDbService.GetCountries();

            foreach (var athlete in model.Athletes)
            {
                athlete.Country = model.Countries.SingleOrDefault(c => c.Id == athlete.CountryId);
            }

            return model;
        }

        public ParticipantsModel GetModelForCreate()
        {
            ParticipantsModel model = new();
            AthleteModel newAthlete = new();

            model.Athletes = new List<AthleteModel> { newAthlete };

            model.Countries = _countriesDbService.GetCountries();
            model.Sports = _sportsDbService.GetSports();

            foreach (var sport in model.Sports)
            {
                newAthlete.Sports.Add(sport.Id, false);
            }

            return model;
        }

        public ParticipantsModel GetModelForEdit(int athleteId)
        {
            ParticipantsModel model = new();

            List<AthleteModel> athletesFromDb = _athletesDbService.GetAthletes();
            AthleteModel athleteForEditing = athletesFromDb.SingleOrDefault(a => a.Id == athleteId);

            model.Athletes = new List<AthleteModel> { athleteForEditing };

            model.Countries = _countriesDbService.GetCountries();
            model.Sports = _sportsDbService.GetSports();

            List<int> sportsIds = _athletesDbService.GetSportsIdsForAthlete(athleteId);

            foreach (var sport in model.Sports)
            {
                if (sportsIds.Contains(sport.Id))
                    athleteForEditing.Sports.Add(sport.Id, true);
                else
                    athleteForEditing.Sports.Add(sport.Id, false);
            }

            return model;
        }
    }
}
