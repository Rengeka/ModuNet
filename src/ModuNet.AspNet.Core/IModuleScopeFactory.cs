using Microsoft.Extensions.DependencyInjection;

namespace ModuNet.AspNet.Core;

public interface IModuleScopeFactory
{
    IServiceScope CreateScope();
}