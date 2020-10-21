namespace FootballLeague.Infrastructure.Tests
{
    using Moq;
    using System.Data.Entity;
    using System.Linq;

    public static class QueryableExtensions
    {

        public static DbSet<T> BuildMockDbSet<T>(this IQueryable<T> source)
       where T : class
        {
            var mock = new Mock<DbSet<T>>();

            mock.As<IQueryable<T>>()
                .Setup(x => x.Provider)
                .Returns(source.Provider);

            mock.As<IQueryable<T>>()
                .Setup(x => x.Expression)
                .Returns(source.Expression);

            mock.As<IQueryable<T>>()
                .Setup(x => x.ElementType)
                .Returns(source.ElementType);

            mock.As<IQueryable<T>>()
                .Setup(x => x.GetEnumerator())
                .Returns(source.GetEnumerator());

            return mock.Object;
        }
    }
}
