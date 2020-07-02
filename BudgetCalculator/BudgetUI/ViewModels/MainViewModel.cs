using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetUI.ViewModels;
using BudgetUI.Views;
using System.Data.Entity;
using BudgetPosts;

namespace BudgetUI.ViewModels
{
    public class MainViewModel : Conductor<object>
    {        
        public void MoneyPage()
        {
            ActivateItem(new MoneyPageViewModel());
        }
        public void SpendingsPage()            
        {            
            ActivateItem(new SpendingsPageViewModel());
        }
    }
}
