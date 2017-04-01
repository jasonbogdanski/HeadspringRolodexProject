using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Environment = NHibernate.Cfg.Environment;
using NHibernate.Tool.hbm2ddl;
using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace HeadSpringRolodexProject.IntegrationTests.DataAccessLayer.NHibernate
{
    public class NHibernateFixtureBase
    {
        #region Fields

        private static Configuration Configuration;
        protected ISessionFactory SessionFactory;
        protected ISession session;

        #endregion // Fields

        #region Construction

        protected NHibernateFixtureBase(string assemblyWithMappings,
                                        string serverName, string databaseName,
                                        string username, string password)
        {
            CreateSessionFactory(
                assemblyWithMappings,
                BuildConnectionString(serverName, databaseName, username, password));
        }

        protected NHibernateFixtureBase(string assemblyWithMappings)
        {
            Assembly assembly = Assembly.Load(assemblyWithMappings);
            CreateSessionFactory(assembly);
        }

        protected NHibernateFixtureBase(Assembly assembly)
        {
            CreateSessionFactory(assembly);
        }

        #endregion // Construction

        #region Implementation

        private void CreateSessionFactory(Assembly assembly)
        {

            this.SessionFactory = Fluently.Configure()
                                    .Database(SQLiteConfiguration.Standard.InMemory)
                                    .Mappings(m =>
                                    m.FluentMappings
                                        .AddFromAssembly(assembly))
                                        .ExposeConfiguration(cfg => Configuration = cfg)
                                    .BuildSessionFactory();


            ISession session = this.SessionFactory.OpenSession();

            var export = new SchemaExport(Configuration);
            export.Execute(true, true, false, session.Connection, null);

            session.Close();

        }

        private void CreateSessionFactory(string assemblyName, string connectionString)
        {
            Assembly assemblyWithMappings = Assembly.Load(assemblyName);

            this.SessionFactory = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(MsSql2005Dialect).AssemblyQualifiedName)
                .SetProperty(Environment.ShowSql, "true")
                .SetProperty(Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, connectionString)
                .AddAssembly(assemblyWithMappings)
                .BuildSessionFactory();

            using (var schemaSession = SessionFactory.OpenSession())
            {
                new SchemaExport(Configuration).Execute(true, true, true, schemaSession.Connection, Console.Out);
            }
        }

        private static string BuildConnectionString(string serverName, string databaseName,
                                                    string username, string password)
        {
            return string.Format(
                "Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                serverName, databaseName, username, password);
        }

        public void Dispose()
        {
            session.Dispose();
        }

        #endregion // Implementation

    } // class NHibernateFixtureBase
}
