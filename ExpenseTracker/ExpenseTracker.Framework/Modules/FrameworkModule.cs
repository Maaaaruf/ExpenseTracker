using Autofac;
using ExpenseTracker.Framework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Modules
{
    public class FrameworkModule : Module
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _migrationAssemblyName = migrationAssemblyName;
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

        }
    }
}
