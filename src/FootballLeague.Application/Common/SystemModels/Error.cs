namespace FootballLeague.Application.Common.SystemModels
{
    using System;

    public class Error
    {
        public Error(Exception exception)
        {
            this.Type = exception.GetType().Name;
            this.Message = exception.Message;
        }

        public string Type { get; private set; }

        public string Message { get; private set; }
    }
}