using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace HeadSpringRolodexProject.Core.Web.Infrastructure
{
    public class EntityModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var original = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (original != ValueProviderResult.None)
            {
                var originalValue = original.FirstValue;
                int id;
                if (int.TryParse(originalValue, out id))
                {
                    var dbContext = bindingContext.HttpContext.RequestServices.GetService<EmployeeRolodexContext>();
                    var entity = await dbContext.Set(bindingContext.ModelType).FindAsync(id);

                    bindingContext.Result = ModelBindingResult.Success(entity);
                }
            }
        }
    }
}
