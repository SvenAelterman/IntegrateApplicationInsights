using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Http.ExceptionHandling;

namespace WebApp.ErrorHandler
{
    /// <summary>
    /// For Web API 2.0
    /// </summary>
    /// <remarks>Per https://azure.microsoft.com/en-us/documentation/articles/app-insights-asp-net-exceptions/#web-api-2x
    /// </remarks>
    public class AiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            if (context != null &&
                context.Exception != null)
            {
                // Add the exception that got us here to the telemetry for AI
                ExceptionTelemetry et = new ExceptionTelemetry(context.Exception);

                DbEntityValidationException dbex = context.Exception as DbEntityValidationException;

                // If this is an Entity Framework entity validation exception
                if (dbex != null && dbex.EntityValidationErrors.Count() > 0)
                    et.Properties.Add("Entity Validation",
                        // Log the first validation error message
                        dbex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);

                new TelemetryClient().TrackException(et);
            }

            base.Log(context);
        }
    }
}
