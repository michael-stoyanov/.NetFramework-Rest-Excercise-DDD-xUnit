namespace FootballLeague.Infrastructure.Repositories
{
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Domain.Entities;
    using FootballLeague.Infrastructure.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class GamesRepository : IGamesRepository
    {
        private readonly LeagueDbContext leagueDb;

        public GamesRepository(LeagueDbContext leagueDb)
        {
            this.leagueDb = leagueDb;
        }

        public TeamsGames GetGameInfoById(int gameId)
        {
            TeamsGames gameInfo = this.leagueDb.TeamsGames.Where(g => g.Game.Id.Equals(gameId))
                .Include(t => t.Game)
                .Include(t => t.GuestTeam)
                .Include(t => t.HomeTeam)
                .SingleOrDefault();

            if (gameInfo is null)
                throw new ArgumentException("There is no registered game with this id.");

            return gameInfo;
        }

        public List<TeamsGames> GetAllPlayedGames()
        => this.leagueDb.TeamsGames.Include("HomeTeam")
                                    .Include("GuestTeam")
                                    .Include("Game")
                                    .ToList();

        public List<FootballGame> GetTeamHomeMatchesById(int teamId)
        {
            Team team = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(teamId));

            if (team is null)
                throw new ArgumentException("There is no registered game with this id.");

            return this.leagueDb.TeamsGames
                                     .Where(tg => tg.HomeTeam.Id.Equals(team.Id))
                                     .Select(tg => tg.Game)
                                     .ToList();
        }

        public List<FootballGame> GetTeamGuestMatchesById(int teamId)
        {
            Team team = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(teamId));

            return this.leagueDb.TeamsGames
                                     .Where(tg => tg.GuestTeam.Id.Equals(team.Id))
                                     .Select(tg => tg.Game)
                                     .ToList();
        }

        public FootballGame RegisterGame(int homeTeamId, int guestTeamId, int homeTeamScore, int guestTeamScore)
        {
            Team homeTeam = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(homeTeamId));
            Team guestTeam = this.leagueDb.Teams.SingleOrDefault(t => t.Id.Equals(guestTeamId));

            var gameInfo = new FootballGame()
            {
                HomeTeamResult = homeTeamScore,
                GuestTeamResult = guestTeamScore
            };

            var newTeamGame = new TeamsGames()
            {
                Game = gameInfo,
                HomeTeam = homeTeam,
                GuestTeam = guestTeam
            };


            this.leagueDb.Games.Add(gameInfo);
            this.leagueDb.TeamsGames.Add(newTeamGame);

            this.leagueDb.SaveChanges();

            return gameInfo;
        }

        public FootballGame UpdateGameScores(int gameId, int homeTeamScore, int guestTeamScore)
        {
            FootballGame game = this.leagueDb.Games.SingleOrDefault(g => g.Id.Equals(gameId));

            if (game is null)
                throw new ArgumentException("There is no registered game with the passed id.");

            game.GuestTeamResult = guestTeamScore;
            game.HomeTeamResult = homeTeamScore;

            this.leagueDb.SaveChanges();

            return game;
        }

        public FootballGame DeleteGame(int gameId)
        {
            FootballGame game = this.leagueDb.Games.SingleOrDefault(g => g.Id.Equals(gameId));

            if (game is null)
                throw new ArgumentException("There is no registered game with the passed id.");

            this.leagueDb.Games.Remove(game);

            this.leagueDb.SaveChanges();

            return game;
        }
    }
}
