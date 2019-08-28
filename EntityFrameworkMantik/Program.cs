using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMantik
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Urunler tablosundan urun adı ve fiyatını filtreleyip seçip göster

            UrunContext context = new UrunContext();
            var urunler = context.Urunler.Select(i=> new //Sınıf kullanmadık o yüzden bunun adı anonymous obje.View üzerine göndermek istedğimizde modeline yazcak birşeyimiz olmaz.
                        {
                            i.UrunAdi,
                            i.Fiyat
                        })
                .ToList();

            foreach (var urun in urunler)
            {
                Console.WriteLine("Urun Adi:{0} Fiyat :{1}", urun.UrunAdi, urun.Fiyat);
            }
            Console.ReadLine();
           
            //Urunler tablosundan Kategori Adi Urun adi ve Fiyata ulasştık
            //@model List<UrunModel>

            UrunContext context = new UrunContext();
            var urunler = context.Urunler.Select(i=> new UrunModel
            {
                UrunAdi= i.UrunAdi,
                Fiyat = i.Fiyat,
                Kategori=i.Kategori.KategoriAdi
            })
                .ToList();
            foreach (var item in urunler)
            {
                Console.WriteLine("Urun Adı:{0} Fiyat:{1} Kategori Adı:{2}", item.UrunAdi, item.Fiyat, item.Kategori);
            }
            Console.ReadLine();

    
            //Her bir kategoriden kategori adına urunlerin adı ve fiyatına ulaşalım

            //Burayı viewe göndersek model olarak
            //@model List<KategoriUrunModel>

            UrunContext context = new UrunContext();
            var kategoriler = context.Kategoriler.Select(i => new KategoriUrunModel
            {
                KategoriAdi = i.KategoriAdi,
                Urunler = i.Urunler.Select(a => new UrunModel
                {
                    UrunAdi=a.UrunAdi,
                    Fiyat = a.Fiyat

                }).ToList()

            }).ToList();

            foreach (var kategori in kategoriler)
            {
                Console.WriteLine("Kategori Adı:{0}", kategori.KategoriAdi);
                foreach (var urun in kategori.Urunler)
                {
                    Console.WriteLine("Urun Adı:{0} Fiyat {1}", urun.UrunAdi, urun.Fiyat);

                }
                Console.WriteLine("*********************************");
            }
            Console.ReadLine();

    


            //BURADAN SONRASI FİLTRELEME İŞLEMİ ÖRNEKLERİ

            //Urunler tablosundan ıdsi 1 olan urunu getir.

            UrunContext context = new UrunContext();
            var urun = context.Urunler.Where(i => i.Id == 1).FirstOrDefault();
            Console.WriteLine("Urun Adi:{0} Fiyatı:{1} Urun Id:{2}", urun.UrunAdi, urun.Fiyat, urun.Id);
           
        
            //Kategori Idsi 1 olan ürünleri ürünler tablosundan getir.

            UrunContext context = new UrunContext();

            var urunler = context.Urunler.Where(i => i.KategoriId == 1).ToList();


            foreach (var item in urunler)
            {
                Console.WriteLine("Kategori Id:{0} Urun Adı:{1} Fiyat :{2}", item.KategoriId, item.UrunAdi, item.Fiyat);
                 
            }



            //Urunler tablosundan Kategori Adı="Telefon" olan urunlerin adını ve stok adetini göster.

            UrunContext context = new UrunContext();
            var urunler = context.Urunler.Where(i => i.Kategori.KategoriAdi == "Telefon").ToList();

            foreach (var item in urunler)
            {
                Console.WriteLine("Kategori Id:{0} Urun Adı :{1} Urun Stok Adeti:{2}", item.KategoriId, item.UrunAdi, item.StokAdeti);
            }


            Console.ReadLine();


            //Kategoriler tablosundan Kategori Adı="Telefon" olan urunlerin adını ve fiyatını göster.
            UrunContext context = new UrunContext();
            var urunler = context.Kategoriler.Where(i => i.KategoriAdi == "Televizyon")
                .Select(a => new KategoriUrunModel
                {
                    KategoriAdi = a.KategoriAdi,
                    Urunler= a.Urunler.Select(c => new UrunModel
                    {
                        UrunAdi=c.UrunAdi,
                        Fiyat=c.Fiyat
                    }).ToList()

                }).ToList();


            foreach (var urun in urunler)
            {
                Console.WriteLine("Kategori Adı:{0}", urun.KategoriAdi);
                foreach (var item in urun.Urunler)
                {
                    Console.WriteLine("Urun Adı:{0} Fiyat{1}", item.UrunAdi, item.Fiyat);

                }
                Console.WriteLine("**************");
            }
            Console.ReadLine();

  

            //BUNDAN SONRAKİ İŞLEMLER İNSERTİNG İLE ALAKALI

            //Normal entityframework kısmında öğrendiğimiz gibi kategori ekleyelim veritabanımıza


          

            UrunContext context = new UrunContext();

            Kategori kategori = new Kategori();

            kategori.KategoriAdi="Mutfak Eşyaları";

            context.Kategoriler.Add(kategori);
            context.SaveChanges();
            foreach (var item in context.Kategoriler)
	            {
                        Console.WriteLine(item.KategoriAdi);
                    
	            }
            Console.ReadLine();
            

            //Ürün üzerinden bir kategori ekleyelim
            

            UrunContext context= new UrunContext();

            Kategori kategori = new Kategori();

            kategori.KategoriAdi="Kişisel Bakım";

            Urun urun = new Urun();
            urun.UrunAdi="Diş Macunu";
            urun.Fiyat= 10;
            urun.StokAdeti=150;

            kategori.Urunler.Add(urun);
            context.Kategoriler.Add(kategori);
            context.SaveChanges();


            var getirilecekler= context.Kategoriler
                
                .Where(i => i.KategoriAdi=="Kişisel Bakım")
                .Select(a => new KategoriUrunModel
                {

                    KategoriAdi= a.KategoriAdi,
                    Urunler = a.Urunler.Select(b => new UrunModel
                    {
                         UrunAdi= b.UrunAdi,
                         Fiyat = b.Fiyat
                    }).ToList()
                }).ToList();
           
            /*

            foreach (var item in getirilecekler)
	            {
                      Console.WriteLine("Katgeori Adı:{0}",item.KategoriAdi);
                foreach (var x in item.Urunler)
	                    {
                    Console.WriteLine("Urun Adi:{0} Fiyat :{1}",x.UrunAdi,x.Fiyat);

	                    }
	            }
           
          


            //Kişisel bakım kategorisine Sabun ürününü ekleyelim

            Urun urun1 = new Urun();
            urun1.UrunAdi="Sabun";
            urun1.Fiyat=5;
            urun1.StokAdeti=100;
            urun1.Kategori = context.Kategoriler.Where(i=>i.KategoriAdi=="Kişisel Bakım").FirstOrDefault();

            context.Urunler.Add(urun1);
            context.SaveChanges();
            /*
            
            foreach (var item in context.Kategoriler.Where(a=> a.KategoriAdi=="Kişisel Bakım"))
	                {
                            foreach (var entity in item.Urunler)
                             {
                                Console.WriteLine(entity.UrunAdi);
	                         }
            }

            Console.ReadLine();
           
         
          //Buradan sonrası Updating işlemi

            //Kategori adı Kişisel Bakım olan Katgeorinin adını Temizlik Malzemeleri olarak değiştir.

          //  UrunContext context = new UrunContext();

            var kategori1= context.Kategoriler.Where(i=>i.KategoriAdi=="Kişisel Bakım").FirstOrDefault();
            if( kategori1 != null)
                {
                 kategori1.KategoriAdi="Temizlik Malzemeleri";
                 context.SaveChanges();
                }
           

            foreach (var item in context.Kategoriler)
	            {
                   Console.WriteLine(item.KategoriAdi);
	            }

            Console.ReadLine();
            

            //Urunlerin fiyatlarına +100 ekleyerek yeni ürün fiyatlarını güncelle.
            UrunContext context = new UrunContext();
            var urunler= context.Urunler.ToList();

            foreach (var urunx in urunler)
	        {
                urunx.Fiyat=urunx.Fiyat+100;
                
	        }
            context.SaveChanges();

            foreach (var x in urunler)
	        {
                Console.WriteLine(x.Fiyat);

	        }
            Console.ReadLine();
          
               //Urunlerin fiyatlarına +100 ekleyerek yeni ürün fiyatlarını güncelle.Ama kategoriler tablosu üzerinden yap

            UrunContext context= new UrunContext();

            var y = context.Kategoriler.Select(i=> new KategoriUrunModel
            {
                KategoriAdi= i.KategoriAdi,
                Urunler=i.Urunler.Select(a=> new UrunModel
                {
                    Fiyat = a.Fiyat

                }).ToList()
            }).ToList();

           foreach (var f in y)
	       {
                foreach (var item in f.Urunler)
	            {
                    item.Fiyat= item.Fiyat+200;

	            }
	        }
           context.SaveChanges();


             foreach (var a in y)
	       {
                foreach (var b in a.Urunler)
	            {
                Console.WriteLine(b.Fiyat);
	            }
	        }


                Console.ReadLine();       
                    
              //BUNDAN SONRAKİ İŞLEMLER DELETİNG İLE İLGİLİ İŞLEMLER

            //Kategori Idsi 1 olan kategoriyi veritabanından sil

            UrunContext context= new UrunContext();
            var kategori = context.Kategoriler.Where(i=> i.Id==1).FirstOrDefault();

            context.Kategoriler.Remove(kategori);
            context.SaveChanges();

            foreach (var item in context.Kategoriler)
            {

                Console.WriteLine(item.KategoriAdi);



            }

            Console.ReadLine();

   

            //KategoriIdsi 2 olan ürünlerin hepsini sil

            UrunContext context = new UrunContext();

            var urunler= context.Urunler.Where(i=> i.KategoriId==2).ToList();

            foreach (var urun in urunler)
	         {
               
                    context.Urunler.Remove(urun);
	          
	         }
            
            context.SaveChanges();


            
            foreach (var getir in context.Urunler)
	         {
              Console.WriteLine("Kategori Id:{0} Urun Adi:{1} Fiyatı:{2}",getir.KategoriId,getir.UrunAdi,getir.Fiyat);
	         }

            Console.ReadLine();

     */

            //BURADAN SONRAKİ İŞLEMLER ORDERİNG İLE İLGİLİ.

            UrunContext context = new UrunContext();
            var urunler= context.Urunler.OrderBy(i=>i.UrunAdi).ToList();

            foreach (var item in urunler)
	        {
                Console.WriteLine(item.UrunAdi);
	        }
            Console.ReadLine();


        }
    }
}
