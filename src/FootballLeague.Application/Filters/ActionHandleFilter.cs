namespace FootballLeague.Application.Filters
{
    using FootballLeague.Application.Common.SystemModels;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ActionHandleFilter : ActionFilterAttribute
    {
        private readonly RequestHelpingProperties helpingProperties;
        private readonly ResponseModel response;
        private readonly MetaData metaData;

        public ActionHandleFilter()
        {
            this.helpingProperties = new RequestHelpingProperties();
            this.response = new ResponseModel();
            this.metaData = new MetaData();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext is null)
                throw new ArgumentNullException(nameof(actionContext));

            this.helpingProperties.RequestId = Guid.NewGuid();
            this.helpingProperties.Stopwatch.Restart();
       }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (context.Exception is null)
            {
                this.metaData.ExecutingTime = this.helpingProperties.Stopwatch.ElapsedMilliseconds;
                this.metaData.ExecutionFinishedTimeUtc = DateTime.UtcNow;
                this.metaData.RequestId = this.helpingProperties.RequestId;
                this.response.MetaData = this.metaData;

                var actionResponse = (ObjectContent)context.Response.Content;

                this.response.Response = actionResponse.Value;

                context.Response = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(this.response, Formatting.Indented))
                };
            }

            base.OnActionExecuted(context);
        }
    }
}
