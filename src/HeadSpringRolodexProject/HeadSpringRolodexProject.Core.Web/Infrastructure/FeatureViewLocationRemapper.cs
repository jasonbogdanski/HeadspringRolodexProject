using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace HeadSpringRolodexProject.Core.Web.Infrastructure
{
    public class FeatureViewLocationRemapper : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(FeatureViewLocationRemapper);
        }

        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            var viewLocationFormats = new[]
            {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/Shared/{0}.cshtml"
            };
            return viewLocationFormats;
        }
    }
}