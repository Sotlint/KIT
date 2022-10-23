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

namespace KIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            if(Worker.Check_authorization(TextBox_login.Text, TextBox_Password.Password) == true)
            {
                Worker.Info(Worker.id);
                if (User_info.Role == 1)
                {
                    Hub Hub_wpf = new Hub();
                    Hub_wpf.Show();
                    Close();
                }
                if (User_info.Role == 0)
                {
                    AdminMenu  AdminMenu_wpf = new AdminMenu();
                    AdminMenu_wpf.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "KIT");
            }

          
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            
            Register Reg_wpf = new Register();
            Reg_wpf.Show();
            Close();
        }
    }
}
