﻿using System;
using System.IdentityModel.Tokens.Jwt;
using BobManager.DataAccess;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using BobManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BobManager.Helpers.Loggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging.Debug;
using BobManager.Domain.Services.Abstraction;
using BobManager.Domain.Services.Implementation;
using BobManager.Domain.Mapping;
using AutoMapper;
using BobManager.Helpers.Managers;

namespace BobManager.API
{
    public class Startup
    {
        private readonly GlobalExceptionManager errManager;
        private readonly ClientErrorManager clientErrManager;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            FileLogger fileLogger = new FileLogger();
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logTrace.log", LogLevel.Trace));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logDebug.log", LogLevel.Debug));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logInformation.log", LogLevel.Information));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logWarning.log", LogLevel.Warning));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logError.log", LogLevel.Error));
            fileLogger.AddFile(new Helpers.Logger.LoggingFile("logs\\logCritical.log", LogLevel.Critical));

            errManager = new GlobalExceptionManager(new ErrorFilter(LogLevel.Error, false), "SERVER ERROR");
            errManager.Logger = fileLogger;
            errManager.DebugMode = true;

            clientErrManager = new ClientErrorManager();
            clientErrManager.AddError(203, "SOME");
        }

        public IConfiguration Configuration { get; }

        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(Configuration["ConnectionString"],
                b => b.MigrationsAssembly("BobManager.API")).UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging()
            );

            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IWalletService, WalletService>();

            services.AddSingleton<IMapper>(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());

            services.AddIdentity<User, IdentityRole>()
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

            services.AddSingleton(errManager);
            services.AddSingleton(clientErrManager);
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

            app.UseHttpsRedirection();
            app.UseMiddlewareException();
            app.UseMvc();
        }
    }
}