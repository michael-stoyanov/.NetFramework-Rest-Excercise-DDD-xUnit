namespace FootballLeague.Application.Services
{
    using AutoMapper;
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Common.Models.DTOs;
    using FootballLeague.Application.Common.Models.InputModels.TeamModels;
    using FootballLeague.Application.Common.Models.ResponseModels;
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RankingsService : IRankingsService
    {
        private readonly IRankingsRepository rankingsRepository;
        private readonly IMapper mapper;

        public RankingsService(IRankingsRepository rankingsRepository, IMapper mapper)
        {
            this.rankingsRepository = rankingsRepository;
            this.mapper = mapper;
        }

        public List<TeamDto> GetTopTenTeams()
        {
            return this.mapper.Map<List<Team>, List<TeamDto>>(this.rankingsRepository.GetTopTenTeams());
        }

        public int GetTeamTotalScore(int teamId)
        {
            return this.rankingsRepository.GetTeamTotalScore(teamId).TotalScore;
        }

        public void AddTeamScoreById(int teamId, int score)
        {
            this.rankingsRepository.AddTeamScore(teamId, score);
        }

        public TeamDto GetChampionshipWinner()
        {
            return this.mapper.Map<TeamDto>(this.rankingsRepository.GetChampionshipWinner());
        }
    }
}
