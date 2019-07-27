using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApplication1.Models
{
    public class Kullanıcı
    {
        public Kullanıcı()
        {
            Mesajlar = new HashSet<Mesaj>();
        }

        public int Id { get; set; }
        public string KullanıcıAdı { get; set; }
        public string Parola { get; set; }
        public string Eposta { get; set; }
        public int Durum { get; set; }
        
        public virtual ICollection<Mesaj> Mesajlar { get; set; }

        public byte[] ResimArray { get; set; }

        [NotMapped]
        public BitmapSource Resim
        {
            get
            {
                BitmapSource resim = null;
                if (ResimArray != null && ResimArray.Length > 0)
                {
                    using (var stream = new MemoryStream(ResimArray))
                    {
                        var kodÇözücü = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        resim = kodÇözücü.Frames[0];
                    }
                }
                return resim;
            }
            set
            {
                byte[] byteDizisi;
                if (value == null)
                {
                    byteDizisi = new byte[0];
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        var kodlayıcı = new JpegBitmapEncoder();
                        kodlayıcı.Frames.Add(BitmapFrame.Create(value));
                        kodlayıcı.Save(stream);
                        byteDizisi = stream.ToArray();
                    }
                }
                ResimArray = byteDizisi;
            }
        }

    }
}
