using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddControllers();
            builder.Services.AddEndpointApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticationScheme = "Jwt";
                Options.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", Options =>
            {
                Options.TokenValidation = new TokenValidationParameters
                {
                    validateAuidence = true,
                    ValidAudience = configuration["JwtTokenAudience"],
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenKey"])),
                    ValidateLifetime = true,
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role,
                };
            });
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.useAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
