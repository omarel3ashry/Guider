﻿using Guider.Application.Contracts.Identity;
using Guider.Domain.Entities;
using Guider.Identity.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddAddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultChallengeScheme =
                options.DefaultForbidScheme =
                options.DefaultScheme =
                options.DefaultSignInScheme =
                options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SignInKey"]!)),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = (context) =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        Debug.WriteLine(accessToken);
                        var path = context.HttpContext.Request.Path;
                        Debug.WriteLine(path);

                        if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/meetingHub")))
                        {
                            Debug.WriteLine("TRUEEEEEEEEEEE");
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorizationCore(opt =>
            {
                opt.AddPolicy(PolicyData.ConsultantPolicyName, p => p.RequireClaim(PolicyData.RoleClaimName, PolicyData.ConsultantClaimValue));
                opt.AddPolicy(PolicyData.ClientPolicyName, p => p.RequireClaim(PolicyData.RoleClaimName, PolicyData.ClientClaimValue));
            });

            services.AddScoped<ITokenFactory, JwtTokenFactory>();
            return services;
        }
    }
}
