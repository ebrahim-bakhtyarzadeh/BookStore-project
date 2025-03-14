﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Shop.Api.Infrastructure.JwtUtil
{
    public static class JwtAuthenticationConfig
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddAuthentication(option =>
            {
                option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"])),
                    ValidIssuer = configuration["JwtConfig:Issuer"],
                    ValidAudience = configuration["JwtConfig:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true
                };
                option.SaveToken = true;
                option.Events = new JwtBearerEvents()
                {
                    OnTokenValidated =async context =>
                    {
                        var customValidate = context.HttpContext.RequestServices.GetRequiredService<CustomJwtValidation>();
                        await customValidate.Validate(context);
                    },
                    
                    
                    // این ایونت برای زمانی هست که یک در خواست سمت سرورر بیاید
                    /*,OnMessageReceived*/
                };
            });
        }
    }
}
