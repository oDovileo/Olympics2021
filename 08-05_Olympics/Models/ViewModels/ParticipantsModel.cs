using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Models.ViewModels
{
    public class ParticipantsModel
    {
        public List<AthleteModel> Athletes { get; set; }
        public List<CountryModel> Countries { get; set; }
        public List<SportModel> Sports { get; set; }
        public List<int> SportInf { get; set; }
    }
}
