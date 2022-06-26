using AutoMapper;
using Business;
using Business.Interfaces;
using Business.Services;
using Data.Data;
using Data.Infrastructure;
using Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Hosting.Server;
using Business.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Business.Models;
using Microsoft.Extensions.Options;

namespace InternetAuction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString_internetAuction = Configuration.GetConnectionString("Internet auction localhost");
            services.AddDbContext<InternetAuctionDbContext>(option => option.UseSqlServer(connectionString_internetAuction));

            var connectionString_auth = Configuration.GetConnectionString("Auth localhost");
            services.AddDbContext<AuthDbContext>(option => option.UseSqlServer(connectionString_auth));

            var authConfig = Configuration.GetSection("Auth");
            CheckinAuthOptions(authConfig.Get<AuthOptions>());
            services.Configure<AuthOptions>(authConfig);

            var hostConfig = new HostConfig(Configuration);
            services.AddSingleton(hostConfig);

            AutomapperProfile automapper = new AutomapperProfile(hostConfig);
            IMapper mapper = new Mapper(new MapperConfiguration(config => config.AddProfile(automapper)));
            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ILotCategoryService, LotCategoryService>();
            services.AddScoped<ILotService, LotService>();
            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<ILotImageService, LotImageService>();
            services.AddScoped<IReceiptService, ReceiptService>();

            services.AddScoped<IUnitOfWorkAuth, UnitOfWorkAuth>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddSingleton<ValidateModelStateAttribute>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            var authConfiguration = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authConfiguration.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authConfiguration.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = authConfiguration.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
            });

        }

        private void CheckinAuthOptions(AuthOptions options)
        {
            if (string.IsNullOrEmpty(options.Issuer))
                throw new ArgumentNullException(nameof(options.Issuer));

            if (string.IsNullOrEmpty(options.Secret))
                throw new ArgumentNullException(nameof(options.Secret));

            if (string.IsNullOrEmpty(options.Audience))
                throw new ArgumentNullException(nameof(options.Audience));

            if (options.TokenLifetime == default)
                throw new ArgumentNullException(nameof(options.TokenLifetime));
        }
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API v1");
                x.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
