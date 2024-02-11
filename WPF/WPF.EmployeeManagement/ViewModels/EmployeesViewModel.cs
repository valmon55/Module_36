using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF.EmployeeManagement.Model;
using WPF.EmployeeManagement.Services;

namespace WPF.EmployeeManagement.ViewModels
{
    public class EmployeesViewModel : INotifyPropertyChanged, IEmployeesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string _filter;
        public string Filter 
        {
            get { return _filter; }    
            set 
            { 
                _filter = value; 
                FillListView();
                FillMessage();
                _logger.Log(_filter);
            }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        private IEmployeeRepository _employeeRepository;
        private ILogger _logger;
        public EmployeesViewModel(IEmployeeRepository employeeRepository, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            FillListView();
            FillMessage();
        }
        public ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        { 
            get
            {
                return _employees;
            }
            set 
            { 
                _employees = value; 
                OnPropertyChanged();
            }
        } 
        private void FillListView()
        {
            if(!String.IsNullOrEmpty(_filter))
            {
                Employees = new ObservableCollection<Employee>( _employeeRepository.GetAll().Where(x => x.FirstName.Contains(_filter)));
            }
            else 
            {
                Employees = new ObservableCollection<Employee>(_employeeRepository.GetAll());
            }
        }
        private void FillMessage()
        {
            if(!String.IsNullOrEmpty(_filter) ) 
            { 
                Message = $"По вашему запросу найдено {Employees.Count()} записей.";
            }
            else
            {
                Message = "Введите данные для поиска.";
            }
        }
    }
}
