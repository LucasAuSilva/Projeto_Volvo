using Nest;
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

        public async Task Invoke(HttpContext context, IElasticClient elastic)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, elastic);
            }
        }

        async private Task HandleExceptionAsync(HttpContext context, Exception ex, IElasticClient elastic)
        {
            //TODO: Gravar log de erro com o trace id

            ErrorResponseVm errorResponseVm;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == "Development" || environment == "Qa")
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

            await this.RegisterLog(elastic, ex, environment);

            var result = JsonConvert.SerializeObject(errorResponseVm);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        async private Task RegisterLog(IElasticClient elastic, Exception ex, string Environment)
        {
            var response = await elastic.IndexDocumentAsync(new ErrorLog(ex.Source, ex.StackTrace, ex.Message, Environment));
            if (response.IsValid)
            {
                Console.WriteLine("Funcionou");
                Console.WriteLine(response.Index);
                return;
            }
            Console.WriteLine("Deu ruim");
        }
    }
}
