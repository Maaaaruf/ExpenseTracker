using Autofac;
using ExpenseTracker.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models.PaymentMethods
{
    public class PaymentMethodBaseModel : UserBaseModel
    {
        public IPaymentMethodService _paymentMethodService;

        public PaymentMethodBaseModel(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public PaymentMethodBaseModel()
        {
            _paymentMethodService = Startup.AutofacContainer.Resolve<IPaymentMethodService>();
        }
    }
}
