using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ExpenseTracker.Web.Areas.User.Models.PaymentMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using Serilog.Core;

namespace ExpenseTracker.Web.Areas.User.Controllers
{
    public class PaymentMethodController : Controller
    {
        public readonly ILogger<PaymentMethodController> _logger;
        public readonly IToastNotification _toaster;

        public PaymentMethodController(ILogger<PaymentMethodController> logger, IToastNotification toast)
        {
            _logger = logger;
            _toaster = toast;
        }

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
            try
            {
                model.Create();
                _toaster.AddSuccessToastMessage($"{model.Name} Created Successfully");
                _logger.LogInformation($"{model.Name} Payment Method Created Successfully");
            }
            catch (Exception e)
            {
                _toaster.AddErrorToastMessage($"{model.Name} Creation Faild");
                _logger.LogInformation($"Faild to Create {model.Name} Payment Method. Exception is: {e}");
            }
            return View(model);
        }
    }
}
