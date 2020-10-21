namespace FootballLeague.Application.Common.SystemModels
{
    using System;

    public class MetaData
    {
        public Guid RequestId { get; set; }

        public long ExecutingTime { get; set; }

        //public string ActionMethod { get; set; }

        public DateTime ExecutionFinishedTimeUtc { get; set; }
    }
}