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
using WpfApplication1.Models;
using WpfApplication1.Pages;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Kullanıcı Kullanıcı;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void mi_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            frame.Source = new Uri("/WpfApplication1;component/Pages/" + mi.Tag + ".xaml", UriKind.Relative);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Kullanıcı !=null)
            {
                Kullanıcı.Durum = 0;
                Veriler.Db.SaveChanges();
            }
        }
    }
}
