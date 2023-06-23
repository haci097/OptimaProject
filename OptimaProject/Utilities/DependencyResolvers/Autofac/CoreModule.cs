using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OptimaProject.Utilities.IoC;
using System.Diagnostics;

namespace OptimaProject.Utilities.DependencyResolvers.Autofac
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
