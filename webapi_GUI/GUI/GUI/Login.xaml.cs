using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
using GUI.Models;
using Newtonsoft.Json;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private static string Apiroot = "http://localhost:5000/api/users";

        public Login()
        {
            InitializeComponent();
        }

        private static Users User = new Users();

        private bool Loginclient(string Username, string Password)
        {
            // Get API Data
            using (WebClient wc = new WebClient())
            {
                string usercheck = wc.DownloadString(Apiroot);
                List<Users> users = JsonConvert.DeserializeObject<List<Users>>(usercheck);

                foreach (var i in users)
                {
                    
                    if (Username == i.Uname)
                    {
                        
                        if (Password == i.Passwrd)
                        {
                            
                            User = i;
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Loginclient(Username.Text, Password.Password.ToString()))
            {

               
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Your credentials are incorrect");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }

}