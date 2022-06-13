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
using MyStore.DTOs;
using MyStore.Entities;
using MyStore.Interfaces;
using MyStore.Profiles;
using MyStore.Repository;
using MyStore.Services;
using MyStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore
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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyStore", Version = "v1" });
            //});            

            AddSwaggerDoc(services);

            void AddSwaggerDoc(IServiceCollection services)
            {
                services.AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme.
                                     Enter 'Bearer' [space] and then your token in the text input below.
                                     Example: 'Bearer 12345abcdef'.",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",



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
                                Scheme = "0auth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,


                            },
                            new List<string>()
                        }
                    });
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyStore", Version = "v1" });

                });
            }


            services.AddDbContextPool<MyStoreContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MapperInitilizer));
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped(typeof(IBaseCrudDataService<,>), typeof(BaseCrudDataService<,>));


            #region
            //services.AddTransient<IGenericRepository<Customer>, IGenericRepository<Customer>>();
            //services.AddTransient<IGenericRepository<Category>, IGenericRepository<Category>>();
            //services.AddTransient<IGenericRepository<FidelityCard>, IGenericRepository<FidelityCard>>();
            //services.AddTransient<IGenericRepository<Order>, IGenericRepository<Order>>();
            //services.AddTransient<IGenericRepository<Product>, IGenericRepository<Product>>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyStore v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.ConfigureExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
