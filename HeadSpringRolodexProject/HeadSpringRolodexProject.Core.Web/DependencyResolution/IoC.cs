using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace HeadSpringRolodexProject.Core.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize(IConfigurationRoot configuration)
        {
            var defaultRegistry = new DefaultRegistry(configuration);
            return new Container(defaultRegistry);
        }

        public static IServiceProvider BuildServiceProvider(IServiceCollection services, IConfigurationRoot configuration)
        {
            var container = Initialize(configuration);

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }
    }
}
