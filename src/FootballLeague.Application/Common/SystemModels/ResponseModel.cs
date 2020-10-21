namespace FootballLeague.Application.Common.SystemModels
{
    public class ResponseModel
    {
        public object Response { get; set; } = new object();

        public Error Error { get; set; }

        public MetaData MetaData { get; set; }
    }
}
