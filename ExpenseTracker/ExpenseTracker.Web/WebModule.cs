using Autofac;
using ExpenseTracker.Web.Areas.User.Models.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreatePaymentMethodModel>();
            builder.RegisterType<PaymentMethodBaseModel>();
            builder.RegisterType<PaymentMethodModel>();
            builder.RegisterType<EditPaymentMethodModel>();

            base.Load(builder);
        }
    }
}
