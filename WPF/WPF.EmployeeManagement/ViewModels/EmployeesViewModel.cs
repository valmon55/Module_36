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

namespace WPF.EmployeeManagement.ViewModels
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private EmployeeRepository _employeeRepository;
        private string _filter;
        public string Filter 
        {
            get { return _filter; }    
            set { _filter = value; }
        }
        public EmployeesViewModel()
        { 
            _employeeRepository= new EmployeeRepository();
            FillListView();
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
            if(!String.IsNullOrEmpty(Filter))
            {
                _employees= new ObservableCollection<Employee>( _employeeRepository.GetAll().Where(x => x.FirstName.Contains(_filter)));
            }
            else 
            {
                _employees = new ObservableCollection<Employee>(_employeeRepository.GetAll());
            }
        }
    }
}
