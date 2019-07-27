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
    /// Interaction logic for ProfilDuzenlePage.xaml
    /// </summary>
    public partial class ProfilDuzenlePage : Page
    {
        public Kullanıcı duzenlenicekKullanıcı;
        public ProfilDuzenlePage()
        {
            InitializeComponent();
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            duzenlenicekKullanıcı.KullanıcıAdı = tbkullanıcıadı.Text;
            duzenlenicekKullanıcı.Parola = tbparola.Text;
            duzenlenicekKullanıcı.Eposta = tbeposta.Text;
            Veriler.Db.SaveChanges();
            NavigationService.Navigate(new Sohbet());
        }
    }
}
