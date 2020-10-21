namespace FootballLeague.Infrastructure.Tests
{
    using FootballLeague.Domain.Entities;
    using FootballLeague.Infrastructure.Persistence;
    using FootballLeague.Infrastructure.Repositories;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class TeamRepositoryTests
    {

        [Fact]
        public void GetAllTeamsTestShouldSucceed()
        {
            // Arrange 
            var emptyTeams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "test name"
                }
            }.AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act
            var teams = teamRepository.GetAllTeams();

            // Assert
            Assert.NotEmpty(teams);
        }

        [Fact]
        public void GetAllTeamsTestShouldFail()
        {
            // Arrange 
            var emptyTeams = new List<Team>().AsQueryable<Team>().BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => teamRepository.GetAllTeams());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetTeamByIdShouldSucceed(int teamId)
        {
            // Arrange 
            var teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "test name"
                },
                new Team()
                {
                    Id = 2,
                    Name = "test name 2"
                }
            }.AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(teams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act
            var teamById = teamRepository.GetTeamById(teamId);

            // Assert
            Assert.Equal(teamId, teamById.Id);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        public void GetTeamByIdShouldFail(int teamId)
        {
            // Arrange 
            var teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "test name"
                },
                new Team()
                {
                    Id = 2,
                    Name = "test name 2"
                }
            }.AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(teams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => teamRepository.GetTeamById(teamId));
        }

        [Theory]
        [InlineData("пияници АД")]
        [InlineData("алкохолици ООД")]
        public void CreateTeamShouldSucceed(string teamName)
        {
            // Arrange 
            var teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "test name"
                },
                new Team()
                {
                    Id = 2,
                    Name = "test name 2"
                }
            }.AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(teams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act
            var createdTeam = teamRepository.CreateTeam(teamName);

            // Assert
            Assert.Equal(teamName, createdTeam.Name);
        }

        [Theory]
        [InlineData("team 1")]
        [InlineData("team 2")]
        public void CreateTeamShouldFail(string teamName)
        {
            // Arrange 
            var emptyTeams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "team 1"
                },
                new Team()
                {
                    Id = 2,
                    Name = "team 2"
                }
            }
            .AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => teamRepository.CreateTeam(teamName));
        }

        [Theory]
        [InlineData(1, "team 1 changed")]
        [InlineData(2, "team 2 changed")]
        public void ChangeTeamNameShouldSucceed(int teamId, string newTeamName)
        {
            // Arrange 
            var emptyTeams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "team 1"
                },
                new Team()
                {
                    Id = 2,
                    Name = "team 2"
                }
            }
            .AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act
            var newTeam = teamRepository.ChangeTeamName(teamId, newTeamName);

            // Assert
            Assert.Equal(newTeamName, newTeam.Name);
        }

        [Theory]
        [InlineData(1, "team 2")]
        [InlineData(2, "team 1")]
        public void ChangeTeamNameShouldFail(int teamId, string newTeamName)
        {
            // Arrange 
            var emptyTeams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "team 1"
                },
                new Team()
                {
                    Id = 2,
                    Name = "team 2"
                }
            }
            .AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => teamRepository.ChangeTeamName(teamId, newTeamName));
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DeleteTeamShouldSucceed(int teamId)
        {
            // Arrange 
            var emptyTeams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "team 1"
                },
                new Team()
                {
                    Id = 2,
                    Name = "team 2"
                }
            }
            .AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act
            var deletedTeam = teamRepository.DeleteTeam(teamId);

            // Assert
            Assert.Equal(teamId, deletedTeam.Id);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void DeleteTeamShouldFail(int teamId)
        {
            // Arrange 
            var emptyTeams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    Name = "team 1"
                },
                new Team()
                {
                    Id = 2,
                    Name = "team 2"
                }
            }
            .AsQueryable()
            .BuildMockDbSet();

            var moquedDb = new Mock<LeagueDbContext>();
            moquedDb.Setup(db => db.Teams).Returns(emptyTeams);

            var teamRepository = new TeamRepository(moquedDb.Object);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => teamRepository.DeleteTeam(teamId));
        }
    }
}
