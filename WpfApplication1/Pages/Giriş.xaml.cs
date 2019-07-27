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
    /// Interaction logic for Giriş.xaml
    /// </summary>
    public partial class Giriş : Page
    {
        public Giriş()
        {
            InitializeComponent();

        }

        private void btngiriş_Click(object sender, RoutedEventArgs e)
        {
            
            var b = Veriler.Db.Kullanıcılar.Where(k => k.KullanıcıAdı == tbkullanıcıadı.Text && k.Parola == tbparola.Text).FirstOrDefault();
            if (b != null)
            {

                MessageBox.Show("Giriş yaptınız.");
                b.Durum = 1;
                Sohbet ss = new Sohbet() { Kullanıcı = b };
                ss.tbkullanıcı.Text = b.KullanıcıAdı;
                ss.Listele();
                Veriler.Db.SaveChanges();
                MainWindow.Kullanıcı = b;
                NavigationService.Navigate(ss);
            }else
            {
                MessageBox.Show("Yanlış ıd şifre");
            }
            
        }

        private void btnkayıt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KayıtPage());
        }
    }
}
