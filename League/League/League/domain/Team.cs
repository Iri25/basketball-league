using System;
using System.Collections.Generic;
using System.Text;

namespace League.domain
{
    public class Team : Entity<int>
    {
        public string Name { get; set; }

        public Team(int id, string Name) : base(id)
        {
            this.Name = Name;
        }

        public override string ToString()
        {
            return "Id Team: " +  Id + ", Name: " + Name;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is Team))
                return false;
            Team team = (Team)obj;
                return Name.Equals(team.Name);
        }
    }
}
