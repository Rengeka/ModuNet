using Microsoft.Extensions.DependencyInjection;

namespace ModuNet.AspNet.Core;

public class ModuleScopeFactory(ServiceProvider serviceProvider) : IModuleScopeFactory
{
    public IServiceScope CreateScope() => serviceProvider.CreateScope();
}