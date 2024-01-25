using System;
using System.Collections.Generic;
using System.Text;
using League.domain;
using League.validator;

namespace League.repository
{
    class TeamInFileMemory : InFileRepository<int, Team>
    {
        public TeamInFileMemory(IValidator<Team> Validator, string FileName) : base(Validator, FileName, null)
        {
        }

        protected Team ReadEntity(string line)
        {
            string[] fields = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            return new Team(int.Parse(fields[0]), fields[1]);
        }

        protected string WriteEntity(Team entity)
        {
            return entity.Id + "," + entity.Name;
        }
    }
}