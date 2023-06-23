using Microsoft.Extensions.DependencyInjection;

namespace OptimaProject.Utilities.IoC
{
    public interface ICoreModule
    {
      void Load(IServiceCollection collection);
    }
}
