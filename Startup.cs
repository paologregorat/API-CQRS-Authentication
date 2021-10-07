using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Business.Operatori;
using WebAPI_CQRS.Business.Personale;
using WebAPI_CQRS.Business.Strutture;
using WebAPI_CQRS.Business.TipiCorsi;
using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Authorization;
using WebAPI_CQRS.Domain.Queries.Serializer;
using WebAPI_CQRS.Domain.Queries.Serializer.CalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Serializer.Corsi;
using WebAPI_CQRS.Domain.Queries.Serializer.Movimenti;
using WebAPI_CQRS.Domain.Queries.Serializer.Strutture;
using WebAPI_CQRS.Domain.Queries.Serializer.TipiCorsi;
using WebAPI_CQRS.Domain.Queries.Serializer.TipiMovimenti;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;
using WebAPI_CQRS.Domain.Queries.Serializer.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Serializer.UtentiCorsi;
using WebAPI_CQRS.Infrastructure.Event;

namespace WebAPI_CQRS
{
    public class Startup
    {
        public class ConnectionString
        {
            public string Shenron { get; set; }
        }
        
        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;
            
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddControllers ()
                .AddJsonOptions (o => {
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "Fiver.Security.Bearer",
                        ValidAudience = "Fiver.Security.Bearer",
                        IssuerSigningKey = JwtSecurityKey.Create("grgpla74a26g284d")
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<IUtentiBusiness, UtentiBusiness>();
            services.AddScoped<IUtenteSerializer, UtenteSerializer>();
            services.AddScoped<ICorsiBusiness, CorsiBusiness>();
            services.AddScoped<ICorsoSerializer, CorsoSerializer>();
            services.AddScoped<IOperatoriBusiness, OperatoriBusiness>();
            services.AddScoped<IPersonaleBusiness, PersonaleBusiness>();
            services.AddScoped<IPersonaleSerializer, PersonaleSerializer>();
            services.AddScoped<ITipiCorsiBusiness, TipiCorsiBusiness>();
            services.AddScoped<ITipoCorsoSerializer, TipoCorsoSerializer>();
            services.AddScoped<IStruttureBusiness, StruttureBusiness>();
            services.AddScoped<IStrutturaSerializer, StrutturaSerializer>();
            services.AddScoped<ITipiMovimentiBusiness, TipiMovimentiBusiness>();
            services.AddScoped<ITipoMovimentoSerializer, TipoMovimentoSerializer>();
            services.AddScoped<IMovimentiBusiness, MovimentiBusiness>();
            services.AddScoped<IMovimentoSerializer, MovimentoSerializer>();
            services.AddScoped<IUtentiCorsiBusiness, UtentiCorsiBusiness>();
            services.AddScoped<IUtenteCorsoSerializer, UtenteCorsoSerializer>();
            services.AddScoped<ICalendariCorsiBusiness, CalendariCorsiBusiness>();
            services.AddScoped<ICalendarioCorsoSerializer, CalendarioCorsoSerializer>();
            services.AddScoped<IUtentiCalendariCorsiBusiness, UtentiCalendariCorsiBusiness>();
            services.AddScoped<IUtenteCalendarioCorsoSerializer, UtenteCalendarioCorsoSerializer>();

            var file = File.ReadAllText("appsettings.json");
            dynamic dyn = JsonConvert.DeserializeObject(file);
            
            var connString = (string)dyn.ConnectionString;
            services.AddDbContext<SunshineContext>(options => options.UseNpgsql(connString), ServiceLifetime.Transient);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sunshine", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                EventsHandler.RegisterEvents();
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();  
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin.API v1"));

        }
    }
}
