using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AdminModer.xaml
    /// </summary>
    public partial class AdminModer : Window
    {
        Context_authorization db = new Context_authorization();

        public AdminModer()
        {

            InitializeComponent();
                db.AuthData.Load();
                DataContext = db.AuthData.Local.ToObservableCollection();
            
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu AdminMenu_wpf = new AdminMenu();
            AdminMenu_wpf.Show();
            Close();
            
        }

        private void Button_Obn_Click(object sender, RoutedEventArgs e)
        {
            db.AuthData.Load();
            DataContext = db.AuthData.Local.ToObservableCollection();
            List_AC.Items.Refresh();

        }

        private void Button_Select_Click(object sender, RoutedEventArgs e)
        {
            AuthData_DB? user = List_AC.SelectedItem as AuthData_DB;
            Worker.Info(user.Login_ID);
            ViewAcc viewacc_wpf = new ViewAcc();
            viewacc_wpf.Show();
            Close();
        }


    }
}
