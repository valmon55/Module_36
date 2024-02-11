using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.EmployeeManagement.Services
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {            
            using(var fw = File.AppendText("D:/Temp/Log_wpf.txt"))
            { 
                fw.WriteLine(message); 
            }
        }
    }
}
