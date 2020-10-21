namespace FootballLeague.Application.Services
{
    using AutoMapper;
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels;
    using FootballLeague.Application.Common.Models.InputModels.TeamModels;
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IGamesRepository gamesRepository;
        private readonly IMapper mapper;

        public TeamService(ITeamRepository teamRepository,
                           IGamesRepository gamesRepository,
                           IMapper mapper)
        {
            this.teamRepository = teamRepository;
            this.gamesRepository = gamesRepository;
            this.mapper = mapper;
        }

        public List<TeamDto> GetAllRegisteredTeams()
        {
            List<Team> registeredTeams = this.teamRepository.GetAllTeams();

            if (registeredTeams is null)
                throw new ArgumentException("There are no teams registered in the championship.");

            var mappedTeams = registeredTeams.Select(t => new TeamDto()
            {
                Id = t.Id,
                Name = t.Name,
                HomeGames = this.mapper.Map<IEnumerable<FootballGame>, List<GameDto>>(this.gamesRepository.GetTeamHomeMatchesById(t.Id)),
                GuestGames = this.mapper.Map<IEnumerable<FootballGame>, List<GameDto>>(this.gamesRepository.GetTeamGuestMatchesById(t.Id))
            }).ToList();

            return mappedTeams;
        }

        public TeamDto GetTeamById(int teamId)
        {
            var team = this.mapper.Map<TeamDto>(this.teamRepository.GetTeamById(teamId));

            return new TeamDto()
            {
                Id = team.Id,
                Name = team.Name,
                HomeGames = this.mapper.Map<IEnumerable<FootballGame>, List<GameDto>>(this.gamesRepository.GetTeamHomeMatchesById(team.Id)),
                GuestGames = this.mapper.Map<IEnumerable<FootballGame>, List<GameDto>>(this.gamesRepository.GetTeamGuestMatchesById(team.Id))
            };
        }

        public TeamDto CreateTeam(CreateTeamInputModel teamInfo)
        {
            if (string.IsNullOrWhiteSpace(teamInfo.TeamName))
                throw new ArgumentException($"'{nameof(teamInfo.TeamName)}' cannot be null or whitespace", nameof(teamInfo.TeamName));

            return this.mapper.Map<TeamDto>(this.teamRepository.CreateTeam(teamInfo.TeamName));
        }

        public TeamDto ChangeTeamName(ChangeTeamNameInputModel teamNames)
        {
            return this.mapper.Map<TeamDto>(this.teamRepository.ChangeTeamName(teamNames.TeamId, teamNames.NewTeamName));
        }

        public TeamDto DeleteTeam(DeleteTeamInputModel teamToDelete)
        {
            var deletedTeam = this.teamRepository.DeleteTeam(teamToDelete.TeamId);

            if (deletedTeam is null)
                throw new ArgumentException("There is no registered team with this name");

            return this.mapper.Map<TeamDto>(deletedTeam);
        }
    }
}
