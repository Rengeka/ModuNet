using Microsoft.Extensions.DependencyInjection;
using ModuNet.AspNet.Core;
using ModuNet.SourceGenerators.Essentials.Attributes;
using SampleModule.Application;

namespace SampleModule.Bootstrap;

[GenerateCompositionRoot]
public class SampleModule : BaseModule, ISampleModule
{
    protected override IServiceScope CreateScope() => SampleModuleCompositionRoot.CreateScope();
} 