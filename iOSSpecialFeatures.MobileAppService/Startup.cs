using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Swashbuckle.AspNetCore.Swagger;

using iOSSpecialFeatures.Models;
using iOSSpecialFeatures.MobileAppService.Data;
using Microsoft.EntityFrameworkCore;
using GraphiQl;
using iOSSpecialFeatures.MobileAppService.Data.Repositories;
using iOSSpecialFeatures.MobileAppService.Graphs.QueryTypes;
using GraphQL;
using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs;

namespace iOSSpecialFeatures.MobileAppService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            EnsureDbIsUpToDate();
            services.AddDbContext<DataContext>();
            services.AddMvc();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddTransient<IDataContext, DataContext>();
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<GraphQLQuery>();
            services.AddSingleton<NullableGuidGraph>();
            services.AddSingleton<NullableDateTimeGraph>();
            services.AddSingleton<ContactEmailGraph>();
            services.AddSingleton<ContactPhoneGraph>();
            services.AddSingleton<ContactGraph>();
            services.AddSingleton<ContactEmailInput>();
            services.AddSingleton<ContactPhoneInput>();
            services.AddSingleton<ContactInput>();
            services.AddSingleton<Queries>();
            services.AddSingleton<Mutations>();
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new iOSSpecialFeatures.MobileAppService.Graphs.Schema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseGraphiQl("/api/graph");

            //app.Run(async (context) => await Task.Run(() => context.Response.Redirect("/swagger")));
        }

        private static void EnsureDbIsUpToDate()
        {
            using (var context = new DataContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
