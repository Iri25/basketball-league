using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using League.domain;
using League.validator;

namespace League.repository
{
    class ActivePlayerInFileMemory : InFileRepository<int, ActivePlayer>
    {
        protected InFileRepository<int, Team> repositoryTeam;

        public ActivePlayerInFileMemory(IValidator<ActivePlayer> Validator, string FileName, InFileRepository<int, Team> repositoryTeam) : base(Validator, FileName, null)
        {
            this.repositoryTeam = repositoryTeam;
            LoadFromFile();
        }

        protected ActivePlayer ReadEntity(string line)
        {
            string[] fields = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Team Team = repositoryTeam.FindOne(int.Parse(fields[3]));
            return new ActivePlayer(int.Parse(fields[0]), fields[1], fields[2], Team, int.Parse(fields[5]), int.Parse(fields[6]), (PlayerType) Enum.Parse(typeof(PlayerType), fields[4]));
        }

        protected string WriteEntity(ActivePlayer entity)
        {
            return entity.Id + "," + entity.Name + "," + entity.School + "," + entity.Team + "," + entity.NumberOfPointsScored;
        }

        private new void LoadFromFile()
        {
            List<ActivePlayer> activePlayers = DataReader.ReadData<ActivePlayer>("C:\\Users\\HP\\Desktop\\Laborator7\\League\\League\\data\\ActivePlayers.txt", ReadEntity);
                
        }
            
    }
      
}

  