using Newtonsoft.Json;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;
using System.Net;

namespace Projeto_Volvo.Api.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //TODO: Gravar log de erro com o trace id

            ErrorResponseVm errorResponseVm;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Qa")
            {
                errorResponseVm = new ErrorResponseVm(HttpStatusCode.InternalServerError.ToString(),
                                                      $"{ex.Message} {ex?.InnerException?.Message}");
            }
            else
            {
                //Homologação, Pre Prod, Produção...

                errorResponseVm = new ErrorResponseVm(HttpStatusCode.InternalServerError.ToString(),
                                                      "An internal server error has occurred.");
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            LogAPI.RegisterLog(ex.Message, errorResponseVm.Errors[0].Logref, errorResponseVm.TraceId); ;
            var result = JsonConvert.SerializeObject(errorResponseVm);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }

        private void RegistraLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
