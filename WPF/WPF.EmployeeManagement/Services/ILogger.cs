﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.EmployeeManagement.Services
{
    public interface ILogger
    {
        void WriteEvent(string eventMessage);
        void WriteError(string errorMessage);
    }
}
