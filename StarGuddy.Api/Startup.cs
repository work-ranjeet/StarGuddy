using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StarGuddy.Api.Handler;
using StarGuddy.Business.Modules.Mapper;
using StarGuddy.Core.Constants;
using System.Text;

namespace StarGuddy.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IAuthorizationHandler, JwtTokenHandler>();
            services.AddAuthorization(authOption =>
            {
                authOption.AddPolicy(nameof(Policy.JwtToken), policy =>
                {
                    policy.Requirements.Add(new JwtTokenRequirement());
                    //policy.RequireClaim(JwtRegisteredClaimNames.Sid);
                    //policy.RequireClaim(JwtRegisteredClaimNames.Email);
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwtBearerCnfg =>
            {
                var signingKey = jwtBearerCnfg.RequireHttpsMetadata = false;
                jwtBearerCnfg.SaveToken = true;
                jwtBearerCnfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetAppSettingValue(AppSettings.JwtIssuer),
                    ValidAudience = Configuration.GetAppSettingValue(AppSettings.JwtAudience),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetAppSettingValue(AppSettings.JwtSecret)))
                };
            });

            services.AddCors(options => options.AddPolicy("Cors", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.AddMvc(option => { option.AllowEmptyInputInBodyModelBinding = true; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(x =>
            {
                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
                x.ValidateInlineMaps = false;
                x.AddProfile<InitMapper>();
            });
            services.AddHttpContextAccessor();

            //// Dependency Injection
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            Injection.Inject(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");
            app.UseAuthentication();
            app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //    c.RoutePrefix = "";
            //});
        }
    }
}
