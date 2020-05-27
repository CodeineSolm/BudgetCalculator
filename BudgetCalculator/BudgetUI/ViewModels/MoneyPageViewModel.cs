using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPosts;
using System.Windows.Controls;
using BudgetUI.Views;

namespace BudgetUI.ViewModels
{
    public class MoneyPageViewModel : Screen
    {
        private string _money;
        public string Money
        {
            get 
            { 
                return _money; 
            }
            set 
            { 
                _money = value;
                NotifyOfPropertyChange(() => Money);
            }
        }
        private string _discription;
        public string Discription
        {
            get 
            { 
                return _discription;
            }
            set
            { 
                _discription = value;
                NotifyOfPropertyChange(() => Discription);
            }
        }
        public Posts Post { get; set; }
        public void recordClick()
        {
            Post = new Posts();
            Post.Money = Convert.ToDouble(Money);
            Post.Discription = Discription;
            Post.Date = DateTime.Now;
            Money = "";
            Discription = "";
        }
    }
}
