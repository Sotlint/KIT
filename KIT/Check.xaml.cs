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
using System.Windows.Shapes;

namespace KIT
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        public Check()
        {
            InitializeComponent();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            Hub hub_wpf = new Hub();
            hub_wpf.Show();
            Close();
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {

            if(Worker.Check_authorization(User_info.Login, PBox.Password)==true)
            {
                Setting setting_wpf = new Setting();
                setting_wpf.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "KIT");
            }
        }
    }
}
