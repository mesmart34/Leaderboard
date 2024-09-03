using System.Text;
using Leaderboard.API.Authorization.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Leaderboard.API.Authorization;

public static class Auth
{
    public static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration.GetSection(JwtSettings.ConfigSection).Get<JwtSettings>();
        if (jwtSettings == null)
        {
            throw new InvalidOperationException("Jwt settings are not set");
        }
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
            });

        return builder;
    }
}