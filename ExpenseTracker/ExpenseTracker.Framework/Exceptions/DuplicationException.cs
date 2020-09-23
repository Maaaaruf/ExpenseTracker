﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Framework.Exceptions
{
    public class DuplicationException : Exception
    {
        public string DuplicateItemName { get; private set; }
        public DuplicationException(string message, string itemName)
            : base(message)
        {
            DuplicateItemName = itemName;
        }
    }
}