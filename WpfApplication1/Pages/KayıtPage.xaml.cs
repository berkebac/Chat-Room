using Microsoft.Win32;
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

namespace WpfApplication1.Pages
{
    /// <summary>
    /// Interaction logic for KayıtPage.xaml
    /// </summary>
    public partial class KayıtPage : Page
    {
        public KayıtPage()
        {
            InitializeComponent();
        }
        private void btnkaydet_Click_1(object sender, RoutedEventArgs e)
        {
            Kullanıcı yenikullanıcı = new Kullanıcı() { Eposta = tbeposta.Text, KullanıcıAdı = tbkullanıcıadı.Text, Parola = tbparola.Text ,Resim = imgresim.Source as BitmapImage};
            Veriler.Db.Kullanıcılar.Add(yenikullanıcı);
            Veriler.Db.SaveChanges();
            NavigationService.Navigate(new Giriş());

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = " Resim Dosyaları | *.jpg;*.png;*.bmp;*"
            };
            if (ofd.ShowDialog() == true)
            {
                imgresim.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
            }
        }
    }
}
