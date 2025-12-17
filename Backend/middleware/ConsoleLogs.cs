using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace Backend_Flet.middleware
{
    public class ConsoleLogs
    {
        private readonly RequestDelegate _next;

        public ConsoleLogs(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Capture the original response body stream
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                Console.WriteLine($"{DateTime.Now} - Request: {context.Request.Method} {context.Request.Path} - Status: {context.Response.StatusCode}");

                if (context.Response.StatusCode >= 400)
                {
                    // Reset the stream position to read the response body
                    responseBody.Seek(0, SeekOrigin.Begin);
                    var responseBodyText = await new StreamReader(responseBody).ReadToEndAsync();
                    Console.WriteLine($"{DateTime.Now} - Error Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path} {context.Response.ContentType}");
                    Console.WriteLine($"Response Body: {responseBodyText}");

                    // Reset the stream position for the client to read
                    responseBody.Seek(0, SeekOrigin.Begin);
                    await responseBody.CopyToAsync(originalBodyStream);
                }

                // Restore the original stream
                context.Response.Body = originalBodyStream;
            }
        }
    }

}