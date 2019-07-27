using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Models
{
    public class Mesaj
    {
        public int Id { get; set; }
        public string Gönderi { get; set; }
        public DateTime Zaman { get; set; }
        [ForeignKey("Kullanıcı")]
        public int KullanıcıId { get; set; }
        public virtual Kullanıcı Kullanıcı { get; set; }
    }
}
