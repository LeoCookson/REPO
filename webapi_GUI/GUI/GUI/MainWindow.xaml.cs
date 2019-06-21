using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Newtonsoft.Json;
using GUI.Models;




namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string Apiroot = "http://localhost:5000/api";

        public MainWindow()
        {

            InitializeComponent();
          //  GUIGrid.ItemsSource = GetDataFromApi();
        }

        public List<Movies> GetDataFromApi()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"{Apiroot}/movies");
               

                List<Movies> movies = JsonConvert.DeserializeObject<List<Movies>>(json);

                return movies;
            }
        }

        public Movies GetSelectedItem()
        {
            var x = GUIGrid.SelectedIndex;
            var movies = GetDataFromApi();
            return movies[x];
        }

     
       


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int count = 0;

            if (count == 0)
            {
                GUIGrid.ItemsSource = GetDataFromApi();

                User_fname.Text = $"";
                User_lname.Text = $"";

                
            }
           
            else
            {
                MessageBox.Show("Button does not work");
            }

            count++;


        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            MessageBox.Show("Button does not work");

        }

        public string Updateuser(string Fname, string Lname, string passwrd)
        {
          Users user = new Users();
            user.Uname = Lname;
            user.Fname = Fname;
            user.Passwrd = passwrd;

            string json = JsonConvert.SerializeObject(user);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{Apiroot}/users/{Fname}");
            req.Method = "PUT";
            req.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            };

            var httpResponse = (HttpWebResponse)req.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opening update user");

            Adduser adduser = new Adduser();
            adduser.Show();
            this.Close();





        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Loggin out");


            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}













