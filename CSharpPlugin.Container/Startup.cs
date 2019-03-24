using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSharpPlugin.Library;
using McMaster.NETCore.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CSharpPlugin.Container
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
           
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging")); //log levels set in your configuration
            loggerFactory.AddDebug(); //does all log levels
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

           



            var dep = new Dependency(loggerFactory.CreateLogger<Dependency>());
            dep.ComesFrom = typeof(Startup).FullName;

            //Option 1: load from a single plugin file

            var loader = PluginLoader.CreateFromAssemblyFile(
           assemblyFile: "C:\\Temp\\CSharpPlugin\\Plugins\\netcoreapp2.0\\CSharpPlugin.Plugin.dll",
           sharedTypes: new[] { typeof(IPlugin), typeof(Dependency), typeof(ILogger) });

            foreach (var pluginType in loader
                    .LoadDefaultAssembly()
                    .GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract))
                {                    
                      var plugin = (IPlugin)Activator.CreateInstance(pluginType);
                     plugin.Register(dep);
                      Console.WriteLine($"Created plugin instance ");
                      plugin.DoThings();
                }
            


        }
    }
}
