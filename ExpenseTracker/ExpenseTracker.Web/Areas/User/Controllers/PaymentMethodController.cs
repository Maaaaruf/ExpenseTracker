using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ExpenseTracker.Web.Areas.User.Models.PaymentMethods;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Web.Areas.User.Controllers
{
    public class PaymentMethodController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<PaymentMethodBaseModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = Startup.AutofacContainer.Resolve<PaymentMethodBaseModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePaymentMethodModel model)
        {
            
            return View(model);
        }
    }
}
