namespace FootballLeague.Application.Common.SystemModels
{
    using System;
    using System.Diagnostics;

    public class RequestHelpingProperties
    {
        public Guid RequestId { get; set; }

        public Stopwatch Stopwatch { get; } = new Stopwatch();

        public Exception Exception { get; set; }
    }
}
