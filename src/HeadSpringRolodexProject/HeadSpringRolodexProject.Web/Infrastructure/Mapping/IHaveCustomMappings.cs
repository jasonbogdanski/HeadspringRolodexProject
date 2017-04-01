using AutoMapper;

namespace HeadSpringRolodexProject.Web.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
