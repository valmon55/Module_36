using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WPF.EmployeeManagement.Model;
using WPF.EmployeeManagement.Services;
using WPF.EmployeeManagement.ViewModels;
using WPF.EmployeeManagement.Views;

namespace WPF.EmployeeManagement
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = new UnityContainer();
            
            unityContainer.RegisterType<IEmployeeViewModel, EmployeeViewModel>();
            unityContainer.RegisterType<IEmployeeRepository,EmployeeRepository>();
            unityContainer.RegisterType<IEmployeesViewModel,EmployeesViewModel>();
            unityContainer.RegisterType<ILogger,Logger>();

            unityContainer.Resolve<EmployeesView>().Show();
        }
    }
}
