namespace FootballLeague.Application.Filters
{
    using FootballLeague.Application.Common.SystemModels;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Web.Http.Filters;

    public class ExceptionHandleFilter : ExceptionFilterAttribute
    {
        private readonly ResponseModel response;
        private readonly MetaData metaData;

        public ExceptionHandleFilter()
        {
            this.response = new ResponseModel();
            this.metaData = new MetaData();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            var mostInnerException = this.GetMostInnerException(context.Exception);

            // TODO: Hide database exceptions with some generic message and maybe custom type for the attackers eyezzz 

            this.metaData.RequestId = Guid.NewGuid();
            this.metaData.ExecutionFinishedTimeUtc = DateTime.UtcNow;

            this.response.Error = new Error(mostInnerException);
            this.response.MetaData = this.metaData;

            context.Response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(this.response, Formatting.Indented )),
                // TODO: fix this if it's needed.
                StatusCode = System.Net.HttpStatusCode.BadRequest         
            };
        }

        private Exception GetMostInnerException(Exception exception)
        {
            if (exception.InnerException is null)
                return exception;

            return this.GetMostInnerException(exception.InnerException);
        }
    }
}
