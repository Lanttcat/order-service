using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using orderService.Infrastructures.Bootstrap.DatabaseModules;

namespace orderService.Infrastructures.Bootstrap
{
    public class Bootstrapper
    {
        private readonly IServiceCollection services;
        private readonly IServiceModule[] modules;

        public Bootstrapper(IServiceCollection services, IServiceModule customDbModule = null)
        {
            this.services = services;
            modules = new[]
            {
                customDbModule ?? new SqliteDatabase()
            };
        }

        public void Bootstrap()
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            foreach (IServiceModule serviceModule in modules)
            {
                serviceModule.Load(services);
            }
        }
    }
}