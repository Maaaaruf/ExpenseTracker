using System;
using System.Collections.Generic;
using System.Text;
using ExpenseTracker.Data;

namespace ExpenseTracker.Framework.Entities
{
    public class PaymentMethod : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
