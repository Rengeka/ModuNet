using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Core;
using SampleModule.Application;

namespace SampleModule.Bootstrap;

public class SampleModule([FromKeyedServices(typeof(SampleModule))] IModuleScopeFactory moduleScopeFactory) : BaseModule(moduleScopeFactory), ISampleModule { }