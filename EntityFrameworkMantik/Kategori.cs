using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMantik
{
    class Kategori
    {
        public Kategori()
        {
            Urunler = new List<Urun>();
        }
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        //Her kategorinin birden fazla ürünü olabilir.Oyüzden Liste şeklinde tanımlanır.
        public List<Urun> Urunler { get; set; }//Kategori tablosu üzerinden Urunlere ulaşmak istedğimizde kod tarafında kullanırız.
        //Veritabanı tarafında gözükmez burası.Örneğin 2 ıdli kategorinin içinde bulunan ürünleri getir dersek kullanacağız
    }
}
