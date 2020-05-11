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

namespace Banksys
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public User ActiveUser = new User();

        public delegate void PassUsername(TextBox text);

        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserTxt.Text;

            MainWindow main = new MainWindow();
            main.ActiveUser = FindActiveUser(username);
            PassUsername pass = new PassUsername(main.GetUsername);
            pass(this.UserTxt);
            main.Show();
            this.Close();
            
        }
        public User FindActiveUser(string username)
        {
            User ActiveUser = new User();
            string connectionString;
            SqlConnection con;
            connectionString = @"Data Source=LAPTOP-PDEKB4VJ;Initial Catalog=Banksys;Integrated Security=True";
            using (con = new SqlConnection(connectionString))
            {
                string qString = "Select * From Banksys.dbo.Users Where Username =@username ";
                SqlCommand Command = new SqlCommand(qString, con);
                Command.Parameters.AddWithValue("@username", username);
                con.Open();
                using (SqlDataReader Reader = Command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        ActiveUser.name = Reader["Username"].ToString();
                    }
                    con.Close();
                }
            }
            return ActiveUser;
        } 
    }
}
