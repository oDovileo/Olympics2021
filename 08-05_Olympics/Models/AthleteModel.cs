using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Models
{
    public class AthleteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }

        // public List<SportModel> Sports { get; set;}
        public CountryModel Country { get; set; }
        public Dictionary<int, bool> Sports { get; set; } = new();
    }
}
