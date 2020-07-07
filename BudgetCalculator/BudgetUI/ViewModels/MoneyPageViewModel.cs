﻿using Caliburn.Micro;
using System;
using BudgetPosts;
using BudgetUI.Properties;
using System.Windows.Forms;

namespace BudgetUI.ViewModels
{
    public class MoneyPageViewModel : Caliburn.Micro.Screen
    {
        BudgetContext bCon = new BudgetContext();

        //Переменная для пополнения/снятия денег (она связана с текстбоксом при помощи Caliburn.Micro)
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
        //Переменная для описания пополнения/снятия денег (она связана с текстбоксом при помощи Caliburn.Micro)
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
        
        public void recordClick()
        {
            //Создаем новый пост в базу
            Posts Post = new Posts();
            Post.Money = Convert.ToDouble(Money);            
            Post.Discription = Discription;
            Post.Date = DateTime.Now;

            //Добавление в глобальную переменную            
            Settings.Default.MoneyCount += Convert.ToDouble(Money);
            Settings.Default.Save();

            //Вывод на экран глобальной переменной
            SavedMoney = Settings.Default.MoneyCount;

            //Сохраняем пост в базе
            bCon.Posts.Add(Post);
            bCon.SaveChanges(); 
            
            //Очищаем текстбоксы
            Money = "";
            Discription = "";
        }

        public MoneyPageViewModel()
        {
            SavedMoney = Settings.Default.MoneyCount;
        }             
    }
}
