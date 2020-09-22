using Autofac;
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

    }
}
