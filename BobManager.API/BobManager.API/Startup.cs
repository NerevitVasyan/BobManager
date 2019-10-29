using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BobManager.DataAccess;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using BobManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BobManager.Helpers.Extentions;
using BobManager.Helpers.Loggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BobManager.Domain.Interfaces;
using BobManager.Domain.Services;

namespace BobManager.API
{
    public class Startup
    {
        private readonly FileLogger fileLogger = new FileLogger();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logTrace.log", LogLevel.Trace));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logDebug.log", LogLevel.Debug));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logInformation.log", LogLevel.Information));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logWarning.log", LogLevel.Warning));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logError.log", LogLevel.Error));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logCritical.log", LogLevel.Critical));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logNone.log", LogLevel.None));
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(Configuration["ConnectionString"],
                b => b.MigrationsAssembly("BobManager.API"))
            );

            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAccountService, AccountService>();

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMiddlewareException();
            app.UseMvc();
        }
    }
}