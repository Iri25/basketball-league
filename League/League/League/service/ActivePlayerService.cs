using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using League.domain;
using League.repository;

namespace League.service
{
    public class ActivePlayerService : Service<int, ActivePlayer>
    {
        public ActivePlayerService(InFileRepository<int, ActivePlayer> fileRepository) : base(fileRepository)
        {
        }

        public IEnumerable<ActivePlayer> AllActivePlayersFromTeamMatch(int IdTeam, int IdMatch)
        {
            return fileRepository.FindAll().Where(x => x.IdMatch.Equals(IdMatch) && x.Team.Id.Equals(IdTeam));
        }
    }
}