using System;
using System.Collections.Generic;
using System.Text;

namespace League.domain
{
    public class Player : Student
    {
        public Team Team { get; set; }

        public Player(int Id, string Name, string School, Team Team ) : base(Id, Name, School)
        {
            this.Team = Team;
        }

        public override string ToString()
        {
            return base.ToString() + ", Team: " + Team;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            Player player = (Player)obj;
                return Team.Equals(player.Team);
        }
    }
}
