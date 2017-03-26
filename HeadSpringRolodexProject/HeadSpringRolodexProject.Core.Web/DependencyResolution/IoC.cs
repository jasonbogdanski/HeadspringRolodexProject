using System;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace HeadSpringRolodexProject.Core.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }

        public static IServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var container =  Initialize();

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }
    }
}
