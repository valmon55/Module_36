using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model;

namespace WPF.EmployeeManagement.ViewModels
{
    public class EmployeeViewModel : IEmployeeViewModel
    {
        private Employee _employee;
        public Employee Employee 
            { 
                get { return _employee;} 
                set { _employee = value; }
            }
    }
}
