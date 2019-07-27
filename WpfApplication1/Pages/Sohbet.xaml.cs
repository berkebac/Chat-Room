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
using System.Windows.Threading;

namespace WpfApplication1.Pages
{
    /// <summary>
    /// Interaction logic for Sohbet.xaml
    /// </summary>
    public partial class Sohbet : Page
    {
        public Kullanıcı Kullanıcı;

        public Sohbet()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
            Listele();
            lbkullanıcılar.Items.Refresh();
            
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            lbgönderiler.ItemsSource = Veriler.Db.Mesajlar.ToArray();
            lbkullanıcılar.ItemsSource = Veriler.Db.Kullanıcılar.Where(d => d.Durum == 1).ToArray();
            
        }
        private void btngönder_Click(object sender, RoutedEventArgs e)
        {
            Mesaj yenimesaj = new Mesaj() { Gönderi = tbmesaj.Text, Zaman = DateTime.Now, Kullanıcı = Kullanıcı };
            Veriler.Db.Mesajlar.Add(yenimesaj);
            Veriler.Db.SaveChanges();
            lbgönderiler.Items.Refresh();
            Listele();
            tbmesaj.Text = "";
        }

        private void btnprofılduzenle_Click(object sender, RoutedEventArgs e)
        {
            ProfilDuzenlePage pdg = new ProfilDuzenlePage()
            {
                duzenlenicekKullanıcı = Kullanıcı
            };
            pdg.tbkullanıcıadı.Text = Kullanıcı.KullanıcıAdı;
            pdg.tbparola.Text = Kullanıcı.Parola;
            pdg.tbeposta.Text = Kullanıcı.Eposta;
            NavigationService.Navigate(pdg);
        }

        private void btnçıkış_Click(object sender, RoutedEventArgs e)
        {
            Kullanıcı.Durum = 0;
            Veriler.Db.SaveChanges();
            NavigationService.Navigate(new Giriş());
        }
    }
}
