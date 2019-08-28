using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMantik
{
    class Urun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }
        public int StokAdeti { get; set; }

        //Her urunun bir kategorisi vardır.O yüzden
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }//kategori ıdsi yardımıyla o kategorinin tüm bilgilerine ulaşmamızı sağlar.
    }
}
