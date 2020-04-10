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

namespace Banksys
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        List<User> UsersL = new List<User>();

        public Login()
        {
            InitializeComponent();

            UsersL.Add(new User() { id = 0001, admin = true, name = "Jessica Vela", phone = "3477400159", balance = 267000, password = "admin" });
            UsersL.Add(new User() { id = 0002, admin = false, name = "Jorge Reyes", phone = "2102457691", balance = 345981, password = "admin" });
            UsersL.Add(new User() { id = 0003, admin = false, name = "Bill Gates", phone = "3474560239", balance = 108456763982, password = "admin" });
            UsersL.Add(new User() { id = 0004, admin = false, name = "Elon Musk", phone = "3458757384", balance = 81334756238, password = "admin" });

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i < UsersL.Count; i++)
            {
                if ((UserTxt.Text == UsersL[i].name)&&(PasswordTxt.Text == UsersL[i].password))
                {
                    MainWindow Main = new MainWindow();
                    Main.Show();
                    this.Close();
                }
            }
        }
    }
}
