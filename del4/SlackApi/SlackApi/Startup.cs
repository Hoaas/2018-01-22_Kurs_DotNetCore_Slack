using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlackApi.ExternalServices;
using SlackApi.ExternalServices.Interfaces;

namespace SlackApi
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
            // Read appsettings.json, appsettings.Development.json, Azure Settings, User Secrets etc.
            // and parse content into SuperConfig!
            services.Configure<SuperConfig>(Configuration);

            services.AddMvc();

            // Dependecy Injection
            services.AddTransient<IOmdb, Omdb>();
            services.AddTransient<ISpotify, Spotify>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
