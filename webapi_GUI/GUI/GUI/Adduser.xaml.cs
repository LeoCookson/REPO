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

namespace GUI
{
    /// <summary>
    /// Interaction logic for Adduser.xaml
    /// </summary>
    public partial class Adduser : Window
    {
      
        public Adduser()
        {
            InitializeComponent();
        
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User updated");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();



        }

      






    }
}
