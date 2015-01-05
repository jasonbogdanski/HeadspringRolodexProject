using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace HeadSpringRolodexProject.DataAccessLayer.NHibernate
{
    public class DatabaseConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                  .Database(
                  SQLiteConfiguration.Standard.ConnectionString(
                  c => c.FromConnectionStringWithKey("RolodexConnectionString")))
                  .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                  .ExposeConfiguration(BuildSchema)
                  .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            //// delete the existing db on each run
            //if (File.Exists(DbFile))
            //    File.Delete(DbFile);

            //// this NHibernate tool takes a configuration (with mapping info in)
            //// and exports a database schema from it
            //new SchemaExport(config)
            //  .Create(false, true);
        }
    }
}
