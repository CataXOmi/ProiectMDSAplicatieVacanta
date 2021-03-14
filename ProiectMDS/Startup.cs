using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Contexts;
using ProiectMDS.Repositories.VacantaRepository;
using ProiectMDS.Repositories.CazareRepository;
using ProiectMDS.Repositories.FotografieRepository;
using ProiectMDS.Repositories.PachetRepository;
using ProiectMDS.Repositories.RezervareCazareRepository;
using ProiectMDS.Repositories.RezervareRepository;
using ProiectMDS.Repositories.UtilizatorRepository;
using ProiectMDS.Repositories.FacilitateRepository;
using ProiectMDS.Repositories.TichetMasaRepository;
using ProiectMDS.Repositories.RestaurantRepository;
using ProiectMDS.Repositories.MeniuRepository;
using ProiectMDS.Repositories.MancareRepository;
using ProiectMDS.Repositories.BiletRepository;
using ProiectMDS.Repositories.AtractieRepository;


namespace ProiectMDS
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICazareRepository, CazareRepository>();
            services.AddTransient<IFotografieRepository, FotografieRepository>();
            services.AddTransient<IPachetRepository, PachetRepository>();
            services.AddTransient<IRezervareCazareRepository, RezervareCazareRepository>();
            services.AddTransient<IRezervareRepository, RezervareRepository>();
            services.AddTransient<IUtilizatorRepository, UtilizatorRepository>();
            services.AddTransient<IVacantaRepository, VacantaRepository>();
            services.AddTransient<IFacilitateRepository, FacilitateRepository>();
            services.AddTransient<ITichetMasaRepository, TichetMasaRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IMeniuRepository, MeniuRepository>();
            services.AddTransient<IMancareRepository, MancareRepository>();
            services.AddTransient<IBiletRepository, BiletRepository>();
            services.AddTransient<IAtractieRepository, AtractieRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
.    AllowCredentials());
            app.UseMvc();

        }
    }
}
