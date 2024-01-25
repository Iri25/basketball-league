using System;
using System.Collections.Generic;
using System.Linq;
using League.domain;
using League.validator;
using League.repository;
using League.service;
using League.userInterface;

namespace League
{
    class Program
    {
        private static List<string> Teams = new List<string>(new[]
        {
            "Houston Rockets",
            "Los Angeles Lakers",
            "LA Clippers",
            "Chicago Bulls",
            "Cleveland Cavaliers",
            "Utah Jazz",
            "Brooklyn Nets",
            "New Orleans Pelicans",
            "Indiana Pacers",
            "Toronto Raptors",
            "Charlotte Hornets",
            "Phoenix Suns",
            "Portland TrailBlazers",
            "Golden State Warriors",
            "Washington Wizards",
            "San Antonio Spurs",
            "Orlando Magic",
            "Denver Nuggets",
            "Detroit Pistons",
            "Atlanta Hawks",
            "Dallas Mavericks",
            "Sacramento Kings",
            "Oklahoma City Thunder",
            "Boston Celtics",
            "New York Knicks",
            "Minnesota Timberwolves",
            "Miami Heat",
            "Milwaukee Bucks"
        }); 

        private static List<string> Schools = new List<string>(new[]
        {
            "Scoala Gimnaziala \"Horea\"",
            "Scoala Gimnaziala \"Octavian Goga\"",
            "Liceul Teoretic \"Lucian Blaga\"",
            "Scoala Gimnaziala \"Ioan Bob\"",
            "Scoala Gimnaziala \"Ion Creanga\"",
            "Colegiul National Pedagogic \"Gheorghe Lazar\"",
            "Scoala Gimnaziala Internationala SPECTRUM",
            "Colegiul National \"Emil Racovita\"",
            "Colegiul National \"George Cosbuc\"",
            "Scoala Gimnaziala \"Ion Agarbiceanu\"",
            "Liceul Teoretic \"Avram Iancu\"",
            "Scoala Gimnaziala \"Constantin Brancusi\"",
            "Liceul Teoretic \"Onisifor Ghibu\"",
            "Liceul Teoretic \"Onisifor Ghibu\"",
            "Liceul cu Program Sportiv Cluj-Napoca",
            "Liceul Teoretic \"Nicolae Balcescu\"",
            "Liceul Teoretic \"Gheorghe Sincai\"",
            "Scoala \"Nicolae Titulescu\"",
            "Scoala Gimnaziala \"Liviu Rebreanu\"",
            "Scoala Gimnaziala \"Iuliu Hatieganu\"",
            "Liceul Teoretic \"Bathory Istvan\"",
            "Colegiul National \"George Baritiu\"",
            "Liceul Teoretic \"Apaczai Csere Janos\"",
            "Seminarul Teologic Ortodox",
            "Liceul de Informatica \"Tiberiu Popoviciu\"",
            "Scoala Gimnaziala \"Alexandru Vaida – Voevod\"",
            "Liceul Teoretic ELF",
            "Scoala Gimnaziala \"Gheorghe Sincai\" Floresti\""
        }); 



        public static void Main()
        {
            TeamInFileMemory TeamInFileMemory = new TeamInFileMemory(new TeamValidator(), "Teams.txt");
            Service<int, Team> TeamService = new Service<int, Team>(TeamInFileMemory);

            PlayerInFileMemory PlayerInFileMemory = new PlayerInFileMemory(new PlayerValidator(), "Players.txt", TeamInFileMemory);
            Service<int, Player> PlayerService = new Service<int, Player>(PlayerInFileMemory);

            MatchInFileMemory MatchInFileMemory = new MatchInFileMemory(new MatchValidator(), "C:\\Users\\HP\\Desktop\\meci.txt", TeamInFileMemory);
            MatchService meciService = new MatchService(MatchInFileMemory);

            ActivePlayerInFileMemory ActivePlayerInFileMemory = new ActivePlayerInFileMemory(new ActivePlayerValidator(), "ActivePlayers.txt", TeamInFileMemory);
            ActivePlayerService ActivePlayerService = new ActivePlayerService(ActivePlayerInFileMemory);

            string[] name =
           {
                "nume1",
                "nume2",
                "nume3",
                "nume4",
                "nume5",
                "nume6",
                "nume7",
                "nume8",
                "nume9",
                "nume10",
                "nume11",
                "nume12",
                "nume13",
                "nume14",
                "nume15",
                "nume16",
                "nume17",
                "nume18",
                "nume19",
                "nume20",
                "nume21",
                "nume22",
                "nume23",
                "nume24",
                "nume25",
                "nume26",
                "nume27",
                "nume28",
            };

            int id = 0;

            foreach (string team in Teams) TeamInFileMemory.Save(new Team(id++, team));

            for (id = 0; id < 28; id++)
            {
                PlayerInFileMemory.Save(new Player(id, name[id], Schools[id / 2], TeamInFileMemory.FindOne(id)));
            }

            for (id = 0; id < 28; id++)
            {
                MatchInFileMemory.Save(new Match(id, TeamInFileMemory.FindOne(id),
                    TeamInFileMemory.FindOne(id / 2), DateTime.Now));
            }

            Random random = new Random();

            foreach (var match in MatchInFileMemory.FindAll())
            {
                foreach (var players in PlayerInFileMemory.FindAll())
                {
                    if (players.Team.Id.Equals(match.Team1.Id))
                    {
                        ActivePlayerInFileMemory.Save(new ActivePlayer(players.Id, players.Name, players.School,
                            players.Team, match.Id, random.Next(1, 5), PlayerType.Participant));
                    }
                    if (players.Team.Id.Equals(match.Team2.Id))
                    {
                        ActivePlayerInFileMemory.Save(new ActivePlayer(players.Id, players.Name, players.School,
                            players.Team, match.Id, random.Next(3, 11), PlayerType.Participant));
                    }
                    if (!players.Team.Id.Equals(match.Team1.Id))
                    {
                        ActivePlayerInFileMemory.Save(new ActivePlayer(players.Id, players.Name, players.School,
                            players.Team, match.Id, random.Next(13, 18), PlayerType.Participant));
                    }
                    if (!players.Team.Id.Equals(match.Team2.Id))
                    {
                        ActivePlayerInFileMemory.Save(new ActivePlayer(players.Id, players.Name, players.School,
                            players.Team, match.Id, random.Next(7, 8), PlayerType.Participant));
                    }
                }
            }

            UserInterface userInterface = new UserInterface(PlayerService, TeamService, meciService, ActivePlayerService, Teams, Schools);
            userInterface.Run();
        }
    }
}