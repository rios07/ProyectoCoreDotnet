using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ControladoresCore.Base
{
    /// <summary>
    ///     JWT Token generator class using "secret-key"
    ///     more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(string username, string userId)
        {
            // appsetting for Token JWT
            var secretKey = "JWT_SECRET_KEY______";
            var audienceToken = "http://localhost:56958/";
            var issuerToken = "http://localhost:56958/";
            var expireTime = "60";

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            //string userId = "4"; //para test
            var claimsIdentity = new ClaimsIdentity(new[]
                {new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.NameIdentifier, userId)});

            // create token to the user
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}