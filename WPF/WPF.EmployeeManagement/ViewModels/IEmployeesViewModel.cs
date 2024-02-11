using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model;

namespace WPF.EmployeeManagement.ViewModels
{
    public interface IEmployeesViewModel
    {
        string Filter { get; set; }
        string Message { get; set; }
        ObservableCollection<Employee> Employees { get; set; }
    }
}
