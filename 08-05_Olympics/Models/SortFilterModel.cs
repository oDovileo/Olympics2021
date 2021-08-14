using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics2021.Models
{
    public class SortFilterModel
    {        
        public string FilterCountry { get; set; } //'' Lithuania ir kt. saliu dropdown
        public string FilterSport { get; set; } //sporto dropdown
        public string FilterTeamActivity { get; set; } //-1, 0, 1 pasirinkti activity tipa (0 not team)
        public string Sort{ get; set; } //name, sport 
        public string SortVal { get; set; } //Lithuania, basketball, true
    }
}
