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

namespace Lec_97
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(userIDtxt.Text, firstNametxt.Text, lastNametxt.Text, emailtxt.Text);
            userIDtxt.Clear();
            firstNametxt.Clear();
            lastNametxt.Clear();
            emailtxt.Clear();
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            string Showdata = "";
            foreach (string i in DataAccess.GetData())
            {
                Showdata = Showdata + i + "\n";
            }
            MessageBox.Show(Showdata);
        }
    }
}
