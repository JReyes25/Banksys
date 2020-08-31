using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Banksys.Classes;


namespace Banksys.Classes
{
    public class DBConnection
    {
        private string connectionString;
        public string command;
        public SqlConnection con;
        SqlCommand Command;
        string qString;

        public DBConnection()
        {
            this.connectionString = @"Data Source=LAPTOP-PDEKB4VJ;Initial Catalog=Banksys;Integrated Security=True";
            this.con = new SqlConnection(connectionString);
        }
        public void SelectUser(string username, string password)
        {
            qString = "Select * From Banksys.dbo.Users Where Username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND UserPassword = @password COLLATE SQL_Latin1_General_CP1_CS_AS";
            Command = new SqlCommand(qString, this.con);

            Command.Parameters.AddWithValue("@username", username);
            Command.Parameters.AddWithValue("@password", password);
        }
        public void GetInfo(User ActiveUser)
        {
            con.Open();

            using (SqlDataReader Reader = Command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    ActiveUser.password = Reader["UserPassword"].ToString();
                    ActiveUser.name = Reader["Username"].ToString();
                    ActiveUser.userId = Int32.Parse(Reader["UserID"].ToString());
                }
                con.Close();
            }
        }
    }
}
