using System;
using System.Collections.Generic;
using System.Text;
using League.domain;
using League.validator;

namespace League.repository
{
    public  class PlayerInFileMemory : InFileRepository<int, Player>
    {
        private InFileRepository<int, Team> repositoryTeam;

        public PlayerInFileMemory(IValidator<Player> Validator, string FileName, InFileRepository<int, Team> repositoryTeam) : base(Validator, FileName, null)
        {
            this.repositoryTeam = repositoryTeam;
        }

        protected Player ReadEntity(string line)
        {
            string[] fields = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Team Team = repositoryTeam.FindOne(int.Parse(fields[3]));
            return new Player(int.Parse(fields[0]), fields[1], fields[2], Team);
        }

        protected string WriteEntity(Player entity)
        {
            return entity.Id + "," + entity.Name + "," + entity.School + "," + entity.Team;
        }
    }
}
