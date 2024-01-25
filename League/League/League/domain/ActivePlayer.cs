using System;
using System.Collections.Generic;
using System.Text;

namespace League.domain
{
    public class ActivePlayer : Player
    {
        public int IdMatch { get; set; }

        public int NumberOfPointsScored { get; set; }

        public  PlayerType Type { get; set; }

        public ActivePlayer(int Id, string Name, string School, Team Team, int IdMatch, int NumberOfPointsScored, PlayerType Type) : base(Id, Name, School, Team)
        {
            this.IdMatch = IdMatch;
            this.NumberOfPointsScored = NumberOfPointsScored;
            this.Type = Type;
        }

        public override string ToString()
        {
            return base.ToString() + ", Id Match: " + IdMatch + ", Number Of Points Scored: " + NumberOfPointsScored + ", Type: " + Type;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is ActivePlayer))
                return false;
            ActivePlayer activePlayer = (ActivePlayer)obj;
                 return IdMatch.Equals(activePlayer.IdMatch) & NumberOfPointsScored.Equals(activePlayer.NumberOfPointsScored) & Type.Equals(activePlayer.Type);
        }
    }
}