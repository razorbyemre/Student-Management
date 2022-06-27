using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using BLL;
using BLL.Inject;
using BLL.Interfaces;
using Student_Management.Inject;
using Student_Management;
namespace Student_Management
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IDbCRUD dbCRUD;
     
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            var kernel = new StandardKernel(new NinjectRegister(), new Service("SMdbContext"));
            dbCRUD = kernel.Get<IDbCRUD>();
            Window window = new LoginWindow(dbCRUD);
            Current.MainWindow = window;
            Current.MainWindow.Show();
           
        }
        
        

    }
}
