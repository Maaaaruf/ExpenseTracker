using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ExpenseTracker.Web.Areas.User.Models;
using ExpenseTracker.Web.Areas.User.Models.PaymentMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using Serilog.Core;

namespace ExpenseTracker.Web.Areas.User.Controllers
{
    [Area("User")]
    public class PaymentMethodController : Controller
    {
        public readonly ILogger<PaymentMethodController> _logger;
        public readonly IToastNotification _toaster;

        public PaymentMethodController(ILogger<PaymentMethodController> logger, IToastNotification toast)
        {
            _logger = logger;
            _toaster = toast;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<PaymentMethodModel>();
            return View(model);
        }

        public IActionResult GetPayMethods()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<PaymentMethodModel>();
            var data = model.GetPaymentMethods(tableModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            var model = Startup.AutofacContainer.Resolve<CreatePaymentMethodModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreatePaymentMethodModel.Name))]CreatePaymentMethodModel model)
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
            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            var model = Startup.AutofacContainer.Resolve<EditPaymentMethodModel>();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(nameof(EditPaymentMethodModel.Name))] EditPaymentMethodModel model)
        {
            try
            {
                model.Edit();
                _toaster.AddSuccessToastMessage($"{model.Name} Updated Successfully");
                _logger.LogInformation($"{model.Name} Payment Method Updated Successfully");
            }
            catch (Exception e)
            {
                _toaster.AddErrorToastMessage($"{model.Name} Update Faild");
                _logger.LogInformation($"Faild to Update {model.Name} Payment Method. Exception is: {e}");
            }
            return RedirectToAction("index");
        }
    }
}
