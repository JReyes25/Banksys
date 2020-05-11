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
       
        public void GetUsername(TextBox text)
        {
            WelcomeTxt.Text = text.Text;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
