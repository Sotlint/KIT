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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click_Return(object sender, RoutedEventArgs e)
        {
            MainWindow Main_wpf = new MainWindow();
            Main_wpf.Show();
            Close();
        }

        private void Button_F_reg_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text!="" && TextBox_Password.Password != "" && TextBox_FirstName.Text != "" && TextBox_LastName.Text != "" && TextBox_Email.Text != "" && TextBox_Telephone.Text != "" && TextBox_City.Text != "" && TextBox_Street.Text != "" && TextBox_Entrance.Text != "" && TextBox_Floor.Text != "" && TextBox_ApartmentNumber.Text != "")
            {

                if (Worker.Register(TextBox_Login.Text, TextBox_Password.Password, TextBox_LastName.Text, TextBox_FirstName.Text, TextBox_Email.Text, TextBox_Telephone.Text, TextBox_City.Text, TextBox_Street.Text, TextBox_Entrance.Text, TextBox_Floor.Text, TextBox_ApartmentNumber.Text) == true)
                {
                    MessageBox.Show("Успешно!", "KIT");
                    MainWindow Main_wpf = new MainWindow();
                    Main_wpf.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "KIT");
            }
        }
    }
}
