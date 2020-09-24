using ExpenseTracker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models
{
    public class MenuModel
    {
        public IList<MenuItem> MenuItems { get; set; }
    }
}
