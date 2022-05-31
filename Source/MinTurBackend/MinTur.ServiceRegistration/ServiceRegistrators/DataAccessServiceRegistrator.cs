using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.DataAccessInterface.Facades;
using MinTur.ServiceRegistration.Interfaces;

namespace MinTur.ServiceRegistration.ServiceRegistrators
{
    public class DataAccessServiceRegistrator : IServiceRegistrator
    {
        public DataAccessServiceRegistrator() { }

        public void RegistrateServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepositoryFacade, RepositoryFacade>();
			string directory = Directory.GetCurrentDirectory();

            IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(directory)
			.AddJsonFile("appsettings.json")
			.Build();

            var assemblyConfigurationAttribute = typeof(DataAccessServiceRegistrator).Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
            var buildConfigurationName = assemblyConfigurationAttribute?.Configuration;
            if (buildConfigurationName == "TESTING_IN_MEMORY")
            {
                serviceCollection.AddDbContext<DbContext, NaturalUruguayContext>(options => options.UseInMemoryDatabase("NaturalUruguay"));
            }
            else
            {
                serviceCollection.AddDbContext<DbContext, NaturalUruguayContext>();
            }
        }
    }
}
