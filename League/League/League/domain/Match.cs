using System;
using System.Collections.Generic;
using System.Text;

namespace League.domain
{
    public class Match: Entity<int>
    { 
        public Team Team1 { get; set; }

        public Team Team2 { get; set; }

        public DateTime DateTime { get; set; }

        public Match(int Id, Team Team1, Team Team2, DateTime DateTime) : base(Id)
        {
            this.Team1 = Team1;
            this.Team2 = Team2;
            this.DateTime = DateTime;
        }

        public override string ToString()
        {
            return "Id Match: " + Id + ", Team 1: " + Team1 + ", Team 2: " + Team2 + ", Date Time: " + DateTime;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is Match))
                return false;
            Match match = (Match)obj;
                 return Team1.Equals(match.Team1) & Team2.Equals(match.Team1) & DateTime.Equals(match.DateTime);
        }
    }
}
