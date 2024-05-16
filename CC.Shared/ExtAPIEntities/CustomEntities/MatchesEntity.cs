using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.ExtAPIEntities.CustomEntities
{
    public class MatchesEntity : ExtMatches
    {
        public string leagueName { get; set; } = String.Empty;
        public string homeName { get; set; } = String.Empty;
        public string awayName { get; set; } = String.Empty;
    }
}
