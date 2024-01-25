using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using League.domain;
using League.repository;

namespace League.service
{
    public class MatchService : Service<int, Match>
    {
        public MatchService(InFileRepository<int, Match> fileRepository) : base(fileRepository)
        {
        }

        public IEnumerable<Match> AllMatchesCalendarPeriod(DateTime dateTime1, DateTime dateTime2)
        {
            return fileRepository.FindAll().Where(x => x.DateTime >= dateTime1 && x.DateTime <= dateTime2);
        }
    }
}