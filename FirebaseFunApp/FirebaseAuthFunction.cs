using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace TestFunApp
{
    public static class FirebaseAuthFunction
    {
        [FunctionName("FirebaseAuthFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth")] Credentials credentials, HttpRequest req,
            ILogger log)
        {

            log.LogInformation("C# HTTP trigger function processed a request.");
            var ReqHeaders = req.Headers;
            ReqHeaders.TryGetValue("Authorization", out var token);
            var TokenFromHeader = token;

            // code below kept in case we want to pull from body instead of header
            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // var TokenFromRequest = JsonConvert.DeserializeObject<Credentials>(requestBody);
            // var TokenFromBody = credentials.Token;

            var JWTHandler = new JwtSecurityTokenHandler();
            var JWTToken = JWTHandler.ReadToken(TokenFromHeader);
            var ExpDate = JWTToken.ValidTo;
            if (ExpDate < DateTime.UtcNow.AddMinutes(1))
            {
                return new UnauthorizedResult();
            }
            else
            {
                return new OkObjectResult("Valid!"); // {credentials.Token}
            }

        }
    }
    public class Credentials
    {
        public string Token { get; set; }
    }
}
