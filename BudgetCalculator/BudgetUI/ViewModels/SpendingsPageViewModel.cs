using BudgetPosts;
using BudgetUI.Properties;
using Caliburn.Micro;
using System.Data.Entity;
using System.Windows.Forms;

namespace BudgetUI.ViewModels
{
    public class SpendingsPageViewModel : Caliburn.Micro.Screen
    {
        BudgetContext bCon;
        public BindableCollection<Posts> dataGrid { get; set; }
        
        public SpendingsPageViewModel()
        {
            bCon = new BudgetContext();
            bCon.Posts.Load();

            dataGrid = new BindableCollection<Posts>(bCon.Posts.Local.ToBindingList());
        }

        public void Clear()
        {
            DialogResult result = MessageBox.Show("You lose all records, you sure about it?", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                bCon = new BudgetContext();
                bCon.Posts.RemoveRange(bCon.Posts);
                bCon.SaveChanges();

                dataGrid.Clear();

                Settings.Default.MoneyCount = 0;
                Settings.Default.Save();
            }            
        }
    }
}
