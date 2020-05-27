using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPosts;
using System.Windows.Controls;
using BudgetUI.Properties;

namespace BudgetUI.ViewModels
{
    public class MoneyPageViewModel : Screen
    {
        BudgetContext bCon;

        //Переменная для пополнения/снятия денег
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
        //Переменная для описания пополнения/снятия денег
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
        //Переменная для отображения денег
        private double _savedMoney;
        public double SavedMoney
        {
            get 
            { 
                return _savedMoney; 
            }
            set 
            {
                _savedMoney = value;
                NotifyOfPropertyChange(() => SavedMoney);
            }
        }

        public Posts Post { get; set; }
        public void recordClick()
        {
            //Создаем новый пост в базу
            Post = new Posts();
            Post.Money = Convert.ToDouble(Money);            
            Post.Discription = Discription;
            Post.Date = DateTime.Now;

            //Сохраняем пост в базе
            bCon.Posts.Add(Post);
            bCon.SaveChanges();

            //Очищаем текстбоксы
            Money = "";
            Discription = "";
        }
    }
}
