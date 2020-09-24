using ExpenseTracker.Data;
using ExpenseTracker.Framework.Entities;
using ExpenseTracker.Framework.Contexts;

namespace ExpenseTracker.Framework.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod, int, FrameworkContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(FrameworkContext context) : base(context)
        {
        }
    }
}
