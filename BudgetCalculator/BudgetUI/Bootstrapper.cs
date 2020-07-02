using Caliburn.Micro;
using BudgetUI.ViewModels;
using System.Windows;

namespace BudgetUI
{
    public class Bootstrapper : BootstrapperBase
    {        
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
