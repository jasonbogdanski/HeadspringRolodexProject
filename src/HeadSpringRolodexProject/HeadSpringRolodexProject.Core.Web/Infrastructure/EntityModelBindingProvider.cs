using HeadSpringRolodexProject.Core.Web.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HeadSpringRolodexProject.Core.Web.Infrastructure
{
    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return typeof(IEntity).IsAssignableFrom(context.Metadata.ModelType) ? new EntityModelBinder() : null;
        }
    }
}
