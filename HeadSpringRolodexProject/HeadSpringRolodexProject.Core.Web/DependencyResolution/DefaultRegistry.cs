using StructureMap;

namespace HeadSpringRolodexProject.Core.Web.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType(typeof (Startup));
                scan.WithDefaultConventions();
                scan.LookForRegistries();
                scan.AssemblyContainingType<DefaultRegistry>();
            });
        }
    }
}
