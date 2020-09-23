using ExpenseTracker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Areas.User.Models
{
    public class UserBaseModel
    {
        public MenuModel MenuModel { get; set; }

        public UserBaseModel()
        {
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    {
                        new MenuItem
                        {
                            Title = "Books",
                            URL = ""
                        }
                    }
                }
            };
        }
    }
}
