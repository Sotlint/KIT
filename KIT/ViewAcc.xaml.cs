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
    /// Логика взаимодействия для ViewAcc.xaml
    /// </summary>
    public partial class ViewAcc : Window
    {

        public void ins()
        {
            List_Prof.Items.Add(" ");
            List_Prof.Items.Add("Логин: " + User_info.Login);
            List_Prof.Items.Add(" ");
            List_Prof.Items.Add("Фамилия: " + User_info.LastName);
            List_Prof.Items.Add("Имя: " + User_info.FirstName);
            List_Prof.Items.Add("E-mail: " + User_info.E_mail);
            List_Prof.Items.Add("Telephone: " + User_info.Telephone);
            List_Prof.Items.Add(" ");
            List_Prof.Items.Add("Город: " + User_info.City);
            List_Prof.Items.Add("Улица: " + User_info.Street);
            List_Prof.Items.Add("Подьезд: " + User_info.Entrance);
            List_Prof.Items.Add("Этаж: " + User_info.Floor);
            List_Prof.Items.Add("Номер квартиры: " + User_info.ApartmentNumber);
        }

        public ViewAcc()
        {
            InitializeComponent();
            ins();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            AdminModer AdminModer_wpf = new AdminModer();
            AdminModer_wpf.Show();
            Close();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Worker.Delete(User_info.id);
            AdminModer AdminModer_wpf = new AdminModer();
            AdminModer_wpf.Show();
            Close();
        }


    }
}
