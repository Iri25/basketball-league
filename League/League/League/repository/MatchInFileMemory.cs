using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using League.domain;
using League.validator;

namespace League.repository
{
    class MatchInFileMemory : InFileRepository<int, Match>
    {
        string FileName { get; set; }

        private InFileRepository<int, Team> repositoryTeam;

        public MatchInFileMemory(IValidator<Match> Validator, string FileName, InFileRepository<int, Team> repositoryTeam) : base(Validator, FileName, null)
        {
            this.repositoryTeam = repositoryTeam;
            this.FileName = FileName;
        }

        protected  Match ReadEntity(string line)
        {
            string[] fields = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Team Team1 = repositoryTeam.FindOne(int.Parse(fields[1]));
            Team Team2 = repositoryTeam.FindOne(int.Parse(fields[2]));
            return new Match(int.Parse(fields[0]), Team1, Team2, DateTime.Parse(fields[3]));
        }

        protected  string WriteEntity(Match entity)
        {
            return entity.Id + "," + entity.Team1 + "," + entity.Team2 + "," + entity.DateTime;
        }

        //private void SaveAllToFile()
        //{
        //    using (StreamWriter sw = new StreamWriter(FileName))
        //    {
        //        foreach (Match entity in FindAll())
        //        {
        //            string line = entity.Id + "," + entity.Team1 + "," + entity.Team2 + "," + entity.DateTime;
        //            sw.WriteLine(line);
        //        }
        //        sw.Flush();
        //    }
        //}


        //public override Match Save(Match entity)
        //{
        //    Match m  =  base.Save(entity);
            
        //    SaveAllToFile();
        //    return m;
        //}
    }
}