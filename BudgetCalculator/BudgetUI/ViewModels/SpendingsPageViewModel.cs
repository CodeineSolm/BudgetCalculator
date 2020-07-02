using BudgetPosts;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace BudgetUI.ViewModels
{
    public class SpendingsPageViewModel : Screen
    {
        BudgetContext bCon;
        public BindableCollection<Posts> dataGrid { get; set; }
        
        public SpendingsPageViewModel()
        {
            bCon = new BudgetContext();
            bCon.Posts.Load();

            dataGrid = new BindableCollection<Posts>(bCon.Posts.Local.ToBindingList());
        }
    }
}
