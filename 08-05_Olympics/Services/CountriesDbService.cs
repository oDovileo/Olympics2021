﻿using Olympics2021.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Services
{
    public class CountriesDbService
    {
        private readonly SqlConnection _connection;

        public CountriesDbService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<CountryModel> GetCountries()
        {
            List<CountryModel> countries = new();

            _connection.Open();

            using var command = new SqlCommand("SELECT * FROM dbo.Countries;", _connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                CountryModel country = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ISO = reader.GetString(2)
                };

                countries.Add(country);
            }

            _connection.Close();

            return countries;
        }

        public void AddCountry(CountryModel country)
        {
            _connection.Open();

            using var command = new SqlCommand($"INSERT INTO dbo.Countries (Name, ISO)" +
                $"VALUES ('{country.Name}', '{country.ISO}');", _connection);
            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
