using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BudgetPosts;

namespace BudgetUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Posts Posts { get; set; }
        BudgetContext bCon;
        public MainWindow()
        {
            InitializeComponent();
            bCon = new BudgetContext();
        }

        private void recordButton_Click(object sender, RoutedEventArgs e)
        {
            Posts = new Posts();
            Posts.Money = Convert.ToDouble(amountTextbox.Text);
            Posts.Discription = discriptionTextbox.Text;
            Posts.Date = DateTime.Today;
            Properties.Settings.Default.Money += Convert.ToDouble(amountTextbox.Text);
            moneyTextblock.Text = Properties.Settings.Default.Money.ToString();

            bCon.Posts.Add(Posts);
            bCon.SaveChanges();        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            moneyTextblock.Text = Properties.Settings.Default.Money.ToString();
        }
    }
}
