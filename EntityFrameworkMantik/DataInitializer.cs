using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkMantik
{
    class DataInitializer : DropCreateDatabaseAlways<UrunContext>
    {
        protected override void Seed(UrunContext context)
        {
            
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori(){KategoriAdi="Telefon"},
                new Kategori(){KategoriAdi="Tablet"},
                new Kategori(){KategoriAdi="Beyaz Eşya"},
                new Kategori(){KategoriAdi="Televizyon"},
            };
            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();

            List<Urun> urunler = new List<Urun>()
            {
                new Urun(){UrunAdi="Samsung S6",Fiyat=1000,StokAdeti=50,KategoriId=1},
                new Urun(){UrunAdi="Iphone 6S",Fiyat=3000,StokAdeti=150,KategoriId=1},
                new Urun(){UrunAdi="Hp",Fiyat=3000,StokAdeti=25,KategoriId=2},
                new Urun(){UrunAdi="Acer",Fiyat=2000,StokAdeti=70,KategoriId=2},
                new Urun(){UrunAdi="Samsung Tv",Fiyat=6000,StokAdeti=50,KategoriId=4},
                new Urun(){UrunAdi="LG",Fiyat=5000,StokAdeti=50,KategoriId=4},
            };
            foreach (var urun in urunler)
            {
                context.Urunler.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
