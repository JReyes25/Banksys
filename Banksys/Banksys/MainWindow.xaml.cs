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

namespace Banksys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public User ActiveUser = new User();
        
        public List<User> UsersL = new List<User>();
       
        public MainWindow()
        {
            InitializeComponent();

            UsersL.Add(new User() { id = 0001, admin = true, name = "Jessica Vela", phone = "3477400159", balance = 267000, password="admin"});
            UsersL.Add(new User() { id = 0002, admin = false, name = "Jorge Reyes", phone = "2102457691", balance = 345981, password = "admin" });
            UsersL.Add(new User() { id = 0003, admin = false, name = "Bill Gates", phone = "3474560239", balance = 108456763982, password = "admin" });
            UsersL.Add(new User() { id = 0004, admin = false, name = "Elon Musk", phone = "3458757384", balance = 81334756238, password = "admin" });

            ActiveUser=UsersL[0];
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTxt.Text;
            string phone = PhoneTxt.Text;
            float amount = float.Parse(AmountTxt.Text);
            if (ActiveUser.Transfer(amount, name, phone, UsersL) == 1)
            {
                NotificationTxt.Text = "Successful";
            }
            else NotificationTxt.Text = "Nope";
        }
        
    }
}
