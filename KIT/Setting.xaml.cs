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
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {

        public void ins()
        {
            TextBox_Login.Text = User_info.Login;
            TextBox_Password.Text = User_info.Password;

            TextBox_LastName.Text = User_info.LastName;
            TextBox_FirstName.Text = User_info.FirstName;
            TextBox_Email.Text = User_info.E_mail;
            TextBox_Telephone.Text = User_info.Telephone;

            TextBox_City.Text = User_info.City;
            TextBox_Street.Text = User_info.Street;
            TextBox_Entrance.Text = User_info.Entrance;
            TextBox_Floor.Text = User_info.Floor;
            TextBox_ApartmentNumber.Text = User_info.ApartmentNumber;
        }

        public Setting()
        {
            InitializeComponent();
            ins();
        }

        private void Button_Click_Return(object sender, RoutedEventArgs e)
        {
            Hub Hub_wpf = new Hub();
            Hub_wpf.Show();
            Close();
        }

        private void Button_F_reg_Click(object sender, RoutedEventArgs e)
        {

            if (TextBox_Login.Text != "" && TextBox_Password.Text != "" && TextBox_FirstName.Text != "" && TextBox_LastName.Text != "" && TextBox_Email.Text != "" && TextBox_Telephone.Text != "" && TextBox_City.Text != "" && TextBox_Street.Text != "" && TextBox_Entrance.Text != "" && TextBox_Floor.Text != "" && TextBox_ApartmentNumber.Text != "")
            {
                if (Worker.Update(TextBox_Login.Text, TextBox_Password.Text, TextBox_LastName.Text, TextBox_FirstName.Text, TextBox_Email.Text, TextBox_Telephone.Text, TextBox_City.Text, TextBox_Street.Text, TextBox_Entrance.Text, TextBox_Floor.Text, TextBox_ApartmentNumber.Text) == true)
                {
                    Worker.Info(Worker.id);
                    Hub Hub_wpf = new Hub();
                    Hub_wpf.Show();
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
