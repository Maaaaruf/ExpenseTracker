using ExpenseTracker.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models.PaymentMethods
{
    public class PaymentMethodModel : PaymentMethodBaseModel
    {
        public PaymentMethodModel(IPaymentMethodService paymentMethodService) : base(paymentMethodService) { }
        public PaymentMethodModel() : base() { }

        internal object GetPaymentMethods(DataTablesAjaxRequestModel tableModel)
        {
            var data = _paymentMethodService.GetPaymentMethods(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalFiltered,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Id.ToString()
                                
                        }
                    ).ToArray()

            };
        }
    }
}
