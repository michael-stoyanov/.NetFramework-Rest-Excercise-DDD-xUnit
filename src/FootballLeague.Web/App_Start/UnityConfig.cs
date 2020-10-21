namespace FootballLeague.Web
{
    using AutoMapper;
    using FootballLeague.Application.Common.Contracts;
    using FootballLeague.Application.Services;
    using FootballLeague.Domain.Contracts;
    using FootballLeague.Infrastructure.Persistence;
    using FootballLeague.Infrastructure.Repositories;
    using FootballLeague.Web.AutoMapperProfiles;
    using System;
    using Unity;

    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();

              container.RegisterInstance<LeagueDbContext>(new LeagueDbContext());

              // TODO: Assign the profiles with reflection if there is time left
              var mapConf = new MapperConfiguration(opt =>
              {
                  opt.AddProfile(new TeamProfile());
                  opt.AddProfile(new GameProfile());
                  opt.AddProfile(new TeamsGamesProfile());
                  opt.AddProfile(new TeamScoreProfile());
              });

              container.RegisterInstance<IMapper>(mapConf.CreateMapper());

              container.RegisterType<ITeamService, TeamService>();
              container.RegisterType<IGamesService, GamesService>();
              container.RegisterType<ITeamRepository, TeamRepository>();
              container.RegisterType<IGamesRepository, GamesRepository>();

              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}