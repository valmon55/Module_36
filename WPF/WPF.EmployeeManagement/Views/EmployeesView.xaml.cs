﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.EmployeeManagement.Model;
using WPF.EmployeeManagement.Services;
using WPF.EmployeeManagement.ViewModels;

namespace WPF.EmployeeManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : Window
    {
        IEmployeeViewModel _employeeViewModel;
        IEmployeesViewModel _employeesViewModel;
        //ILogger _logger;
        public EmployeesView(IEmployeesViewModel employeesViewModel, IEmployeeViewModel employeeViewModel)
        {
            _employeesViewModel = employeesViewModel;
            _employeeViewModel = employeeViewModel;
            InitializeComponent();
            DataContext= _employeesViewModel;
        }

        private void ListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item is null) 
            {
                return;
            }

            var employee = item as Employee;
            _employeeViewModel.Employee = employee;
            //_logger.WriteEvent(employee.FirstName);
            //MessageBox.Show($"{employee.LastName} \n\r {employee.FirstName} \n\r {employee.Age.ToString()} \n\r" +
            //    $"{employee.Position} \n\r {employee.CompanyName} \n\r {employee.CityName}");
            var employeeView = new EmployeeView(_employeeViewModel);
            employeeView.Show();
        }
    }
}
