using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RetailBrandApi.Models;
using RetailBrandApi.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace RetailBrandApi
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
            // requires using Microsoft.Extensions.Options
            services.Configure<RetailBrandDatabaseSettings>(
                Configuration.GetSection(nameof(RetailBrandDatabaseSettings)));

            services.AddSingleton<IRetailBrandDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<RetailBrandDatabaseSettings>>().Value);

            services.AddSingleton<StyleService>();

            services.AddSingleton<SkuService>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc(options =>
                options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
   
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Sample Retail Brand API", Version = "V1" });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });


            app.UseHttpsRedirection();
            
            app.UseMvc();
        }
    }
}
