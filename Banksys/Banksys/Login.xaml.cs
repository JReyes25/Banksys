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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Banksys.Classes;

namespace Banksys
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public User ActiveUser = new User();
        public DBConnection connection= new DBConnection();

        public Login()
        {
            InitializeComponent();

        }
        private void OnKeyHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                LoginBtn_Click(sender, e);
            }
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserTxt.Text;
            string password = PasswordTxt.Password;

            ActiveUser = FindActiveUser(username, password);
            if((ActiveUser.userId != 0) || (ActiveUser.password=="null") || (ActiveUser.userId==0))
            {
                MainWindow main = new MainWindow(ActiveUser);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The username/password are incorrect. Please review your information and try again.");
            }
        }

        public User FindActiveUser(string username, string password)
        {
            User ActiveUser = new User();
            using (connection.con)
            {
                connection.SelectUser(username, password);
                connection.GetInfo(ActiveUser);
            }
            return ActiveUser;
        } 
    }
}
