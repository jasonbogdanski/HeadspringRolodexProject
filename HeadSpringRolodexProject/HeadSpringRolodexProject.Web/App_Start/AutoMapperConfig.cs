﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Reflection;
using HeadSpringRolodexProject.Web.Infrastructure.Mapping;

namespace HeadSpringRolodexProject.Web.App_Start
{
    public class AutoMapperConfig
    {
        public void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            LoadStandardMappings(types);
            LoadCustomMappings(types);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                        !t.IsAbstract &&
                        !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !t.IsAbstract &&
                        !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t

                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }
    }
}