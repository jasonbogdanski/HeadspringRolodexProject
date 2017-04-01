using HeadSpringRolodexProject.Core.Web.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StructureMap;
using StructureMap.Pipeline;

namespace HeadSpringRolodexProject.Core.Web.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry(IConfiguration configuration)
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType(typeof (Startup));
                scan.WithDefaultConventions();
                scan.LookForRegistries();
                scan.AssemblyContainingType<DefaultRegistry>();
            });

            var builder = new DbContextOptionsBuilder<EmployeeRolodexContext>();
            builder.UseSqlServer(configuration.GetConnectionString("EmployeeRolodexDatabase"));

            For<EmployeeRolodexContext>().Use(() => new EmployeeRolodexContext(builder.Options)).LifecycleIs<TransientLifecycle>();
        }
    }
}
