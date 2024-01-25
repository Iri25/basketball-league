using System;
using System.Collections.Generic;
using System.Linq;
using League.domain;
using League.validator;
using League.service;

namespace League.userInterface
{
    public class UserInterface
    {
        private Service<int, Player> servicePlayer;
        private Service<int, Team> serviceTeam;
        private MatchService serviceMatch;
        private ActivePlayerService serviceActivePlayer;
        private List<string> Teams;
        private List<string> Schools;

        public UserInterface(Service<int, Player> servicePlayer, Service<int, Team> serviceTeam, MatchService serviceMatchs, ActivePlayerService serviceActivePlayer, List<string> Teams, List<string> Schools)
        {
            this.servicePlayer = servicePlayer;
            this.serviceTeam = serviceTeam;
            this.serviceMatch = serviceMatchs;
            this.serviceActivePlayer = serviceActivePlayer;
            this.Teams = Teams;
            this.Schools = Schools;
        }

        private string ReadString(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        private int ReadInt(string text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }

        private void AddPlayer()
        {
            try
            {

                servicePlayer.Save(new Player
                    (
                    ReadInt("Player id:"),
                    ReadString("Player name:"),
                    ReadString("Player school:"),
                    serviceTeam.FindOne(ReadInt("Player team id:"))
                    ));
            }
            catch(ValidationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void AllPlayers()
        {
            foreach (var VARIABLE in servicePlayer.FindAll())
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private void AddTeam()
        {
            try
            {
                serviceTeam.Save(new Team
                    (
                    ReadInt("Team id:"),
                    ReadString("Team name:")
                    ));
            }
            catch (ValidationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void AllTeams()
        {
            foreach (var VARIABLE in serviceTeam.FindAll())
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private void AddMatch()
        {
            try
            {
                serviceMatch.Save(new Match
                    (
                    ReadInt("Match id:"),
                    serviceTeam.FindOne(ReadInt("Team 1 id:")),
                    serviceTeam.FindOne(ReadInt("Team 2 id:")),
                    DateTime.Parse(ReadString("Date dd/mm/yyyy:"))
                    ));
            }
            catch (ValidationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void AllMatchs()
        {
            foreach (var VARIABLE in serviceMatch.FindAll())
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private void AddActivePlayer()
        {
            try
            {
                serviceActivePlayer.Save(new ActivePlayer(
                    ReadInt("Active player id:"),
                    ReadString("Active player name:"),
                    ReadString("Active player school:"),
                    serviceTeam.FindOne(ReadInt("Active player team id")),
                    ReadInt("Match id:"),
                    ReadInt("Number of points scored:"),
                    (PlayerType)Enum.Parse(typeof(PlayerType), ReadString("Player type(Reserve/Participant):"))
                    ));
            }
            catch (ValidationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void AllActivePlayers()
        {
            foreach (var VARIABLE in serviceActivePlayer.FindAll())
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private void AllPlayersOnAGivenTeam()
        {
            int idTeam = ReadInt("Team id:");
            foreach (var VARIABLE in servicePlayer.FindAll())
            {
                if (VARIABLE.Team.Id.Equals(idTeam))
                    Console.WriteLine(VARIABLE);
            }
        }

        private void AllActivePlayersFromTeamMatch()
        {
            foreach (var VARIABLE in serviceActivePlayer.AllActivePlayersFromTeamMatch(
                ReadInt("Team id:"), ReadInt("Match id:")))
                {
                    Console.WriteLine(VARIABLE);
                }
        }

        private void AllMatchesCalendarPeriod()
        {
            foreach (var VARIABLE in serviceMatch.AllMatchesCalendarPeriod(
                DateTime.Parse(ReadString("Starting date dd/mm/yyyy:")),
                DateTime.Parse(ReadString("End date dd/mm/yyyy:"))))
                {
                    Console.WriteLine(VARIABLE);
                }
        }

        private void TheScoreOfAMatch()
        {
            int idMatch = ReadInt("Match id:");
            List<ActivePlayer> list = new List<ActivePlayer>();
            Match match = serviceMatch.FindOne(idMatch);
            Console.Write(match.Team1.Name + " ");
            Console.Write(serviceActivePlayer.FindAll().Where(x => x.Team.Id.Equals(match.Team1.Id)).Sum(x => x.NumberOfPointsScored) + " - ");
            Console.Write(serviceActivePlayer.FindAll().Where(x => x.Team.Id.Equals(match.Team2.Id)).Sum(x => x.NumberOfPointsScored) + " ");
            Console.Write(match.Team2.Name + " ");
        }

        private void Menu()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------\n" +
                              "0. Exit\n" + 
                              "1. Add player\n" + 
                              "2. All players\n" +
                              "3. Add team\n"+
                              "4. All teams\n" + 
                              "5. Add match\n" + 
                              "6. All matchs\n" +
                              "7. Add active player\n" +
                              "8. All active players\n" +
                              "9. All players on a given team\n" +
                              "10. All active players of a team from a certain match\n" +
                              "11. All matches in a certain calendar period\n" +
                              "12. The score from a certain match\n" +
                              "--- ---------------------------------------------------------------------------------------\n"
                );
        }

        public void Run()
        {
            bool ok = true;
            while (ok)
            {
                try
                {
                    Menu();
                    switch (ReadString("Insert the command:"))
                    {

                        case "0":
                            ok = false;
                            break;

                        case "1":
                            Console.WriteLine();
                            AddPlayer();
                            Console.WriteLine();
                            break;

                        case "2":
                            Console.WriteLine();
                            AllPlayers();
                            Console.WriteLine();
                            break;
                        
                        case "3":
                            Console.WriteLine();
                            AddTeam();
                            Console.WriteLine();
                            break;

                        case "4":
                            Console.WriteLine();
                            AllTeams();
                            Console.WriteLine();
                            break;


                        case "5":
                            Console.WriteLine();
                            AddMatch();
                            Console.WriteLine();
                            break;

                        case "6":
                            Console.WriteLine();
                            AllMatchs();
                            Console.WriteLine();
                            break;

                        case "7":
                            Console.WriteLine();
                            AddActivePlayer();
                            Console.WriteLine();
                            break;

                        case "8":
                            Console.WriteLine();
                            AllActivePlayers();
                            Console.WriteLine();
                            break;

                        case "9":
                            Console.WriteLine();
                            AllPlayersOnAGivenTeam();
                            Console.WriteLine();
                            break;

                        case "10":
                            Console.WriteLine();
                            AllActivePlayersFromTeamMatch();
                            Console.WriteLine();
                            break;

                        case "11":
                            Console.WriteLine();
                            AllMatchesCalendarPeriod();
                            Console.WriteLine();
                            break;

                        case "12":
                            Console.WriteLine();
                            TheScoreOfAMatch();
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine("Invalid command!");
                            Console.WriteLine();
                            break;
                    }
                }
                catch (Exception exception)
                {
                    if (exception is ValidationException || exception is FormatException)
                        Console.WriteLine(exception.Message);
                    else
                        throw;
                }
            }
        }
    }
}