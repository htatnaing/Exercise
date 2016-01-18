using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Reflection;
using TextAnalyzer.Interface;
using TextAnalyzer.WPF.IoC;

namespace TextAnalyzer.WPF
{
    
        public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                IocKernel.Initialize(new IocConfiguration());

                base.OnStartup(e);
            }
        }
}
