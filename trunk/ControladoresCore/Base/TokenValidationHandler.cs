using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Tokens;

namespace ControladoresCore.Base
{
    /// <summary>
    ///     Token validator for Authorization Request using a DelegatingHandler
    /// </summary>
    public class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
                return false;
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            var mensaje = "";

            var reqMethod = request.Method.Method;
            System.IO.StreamReader reader = new System.IO.StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string reqBody = reader.ReadToEnd();

            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
            Logger.Info("Request recibida : " + reqMethod + " "+request.RequestUri.OriginalString+" " + reqBody);
            // determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                var response = await base.SendAsync(request, cancellationToken);
                
                var resStatusCode = response.StatusCode.ToString();
                // var resBody= resContent.ReadAsStringAsync().Result;
                Logger.Info("Status Code: " + resStatusCode + ", Reason Phrase: " + response.ReasonPhrase);
                return response;
            }

            try
            {
                var secretKey = "JWT_SECRET_KEY______";
                var audienceToken = "http://localhost:56958/";
                var issuerToken = "http://localhost:56958/";
                var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));

                SecurityToken securityToken;
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                // Extract and assign Current Principal and user
                var claims = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                Thread.CurrentPrincipal = claims;
                HttpContext.Current.User = claims;
                var UserId = claims.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
                request.Properties.Add("userId", UserId);
                //
            
                request.Properties.Add("Token", token);
                var response= await base.SendAsync(request, cancellationToken);

                var resStatusCode = (int) response.StatusCode;
          
               // var resBody= resContent.ReadAsStringAsync().Result;

                Logger.Info("Status Code: "+ resStatusCode + ", Reason Phrase: " + response.ReasonPhrase);

                return response;
            }
            catch (SecurityTokenValidationException)
            {
                Logger.Info("Token Invalido.");
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                Logger.Info("Exception: "+ ex.Message);
                statusCode = HttpStatusCode.InternalServerError;
                mensaje = ex.Message;
            }

            return await Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode)
                {ReasonPhrase = mensaje});
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            if (expires != null)
                if (DateTime.UtcNow < expires)
                    return true;
            return false;
        }
    }
}