using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace UrunSatis
{
    internal class Komutlar
    {
        Connection Baglanti = new Connection();

        public string IDBul(string Tablo)
        {
            Baglanti.Baglan.Open();
            //Bağlantımızı açıyoruz.

            SqlCommand IDKomut = new SqlCommand();

            if (Tablo == "Urunler")
            {
                IDKomut = new SqlCommand("SELECT TOP 1 * FROM " + Tablo + " ORDER BY UrunId DESC", Baglanti.Baglan);
                /*  Daha mobil bir uygulama yapmak istediğim için şöyle bir şey düşündüm. Benim ürün kaydımın id'si sql tarafından
                 *  kaçıncı ürün olduğuna göre belirleniyor. Kullanıcı bu id değerini kendi isteğiyle girmediği için bunu göremeyecekse o zaman
                *  benim göstermem gerekecekti. Bunun içinde kaydettikten sonra kaydettiği kaydı bulup id'sini göstermek yerine,
                *  Veritabanındaki en son id'ye sahip kaydı bulup buna bir arttırıp kayıt ekranında gösterseydim, daha kullanışlı
                *  olurdu diye düşündüm. Elbette bu özelliği hem ürünler için hem müşteriler için kullandım. ve bu sebeple eğer 
                *  bu metodumun parametresine "Urunler" yazılırsa, bu üstteki sorgumla ürünler tablosundaki en son kaydın bulacağım.
                */
            }

            if(Tablo == "Musteriler")
            {
                IDKomut = new SqlCommand("SELECT TOP 1 * FROM " + Tablo + " ORDER BY MusteriId DESC", Baglanti.Baglan);
                //Ama eğer "Musteriler" yazılırsa da, buradaki sorgumda müşteriler tablomdaki en son kaydı bulacağım.
            }


            SqlDataReader IDOkuyucu = IDKomut.ExecuteReader();
            /*Burada ise yazmış olduğumuz komuttan okunacak değerleri SqlDataReader'a aktarıyoruz. Select ifadeleri kullanıp "Execute"
             * etmek için ExecuteReader() kullanırım.
             */

            int SonKayit = 0;

            if (IDOkuyucu.Read())
            //Eğer aradığım özelliklere sahip bir kayıt bulabiliyorsa
            {
                if(Tablo == "Urunler")
                    SonKayit = int.Parse(IDOkuyucu["UrunId"].ToString());
                //Eğer metodun parametresine yazdığımız tablo Ürünler tablosuysa Ürün id'sini bulacak.

                if (Tablo == "Musteriler")
                    SonKayit = int.Parse(IDOkuyucu["MusteriId"].ToString());
                //Eğer metodun parametresine yazdığımız tablo Müşteriler tablosuysa Müşteri id'sini bulacak.


                IDOkuyucu.Close();
                //SqlDataReader'ımızı kapattık.


                Baglanti.Baglan.Close();
                //Bağlantımızı kapatıyoruz.


                return (SonKayit + 1).ToString();
                //Bir arttırdık, stringe çevirdik ve UrunId textboxımızda başarıyla gösterdik.
                //Readonly olduğu için bir müdahele yapılamayacak textbox'ımıza.

                /* Ve return edince derleyici direkt olarak metoddan ayrıldığı için istediğimiz verileri bulduktan sonra bağlantıları kapatıp 
                *Bulduğumuz değeri döndürdük.*/


            }

            IDOkuyucu.Close();
            //SqlDataReader'ımızı kapattık.


            Baglanti.Baglan.Close();
            //Bağlantımızı kapatıyoruz.

            return "1";
            //Eğer derleyici buraya kadar geldiyse daha önce hiç kayıt bulamamıştır ve yukarıdaki if koşuluna girmemiştir.
            //Bu sebeple 1 atıyoruz çünkü ilk kaydımız olacaktır.
        }

        public string[] KategoriBul()
        {
            Connection Baglanti = new Connection();
            //Bağlantı dizemizi kullanabilmek için bağlantı dizemizi tanıttığımız sınıftan nesne türettik.

            Baglanti.Baglan.Open();
            //Bağlantımızı açıyoruz.

            SqlCommand KategoriKomut = new SqlCommand("SELECT UrunKategori FROM Urunler", Baglanti.Baglan);
            /* Bu sorgunun amacı ise, ürün kaydı yaparken kategori seçmek istemem. Yani siz bir laptop ürünü girecekseniz kategoriye "Teknoloji"
            * yazarsınız veya daha önce "Teknoloji" kategorisinde oluşturulmuş bir ürün varsa bunu combobox'tan seçersiniz.
            * Yani, daha önceden oluşturulmuş kategorileri listeler ve Combobox'ın itemleri içerisine ekler. Eğer kullanıcının istediği kategori
            * combobox'in itemleri içinde yoksa kullanıcı kendisi girebilir.
            * Sonuç olarak bu sorguda Urunler tablomdaki daha önce her bir ürüne girilmiş olan butun Kategorileri listeliyorum.
            */

            SqlDataReader KategoriOkuyucu = KategoriKomut.ExecuteReader();
            //Karşımıza çıkacak sonucu SqlDataReader'a atıyoruz.

            ArrayList list = new ArrayList();
            // ArrayList kullanmamın sebebi, listemin uzunluğunun belli olmamasıdır. Listemin uzunluğunu belirlemek için
            // Gidip sql'den bütün kayıtları tek tek yazdırıp programı yavaşlatmak yerine, dinamik yapıda bir Arraylist tanımlayıp,
            // Buraya attığım bilgileri daha sonra string[]'e çevirmenin daha mantıklı olduğunu düşündüm.

            while (KategoriOkuyucu.Read())
            //İstediğim özellikteki kayıtlar okunabildiği, bulunabildiği sürece şunları yap;
            {

                string Kategori = KategoriOkuyucu["UrunKategori"].ToString();

                //Sırayla kategori değerlerimizi alalım ve önce bir dizimize atalım.
                //Kategorileri içeren dizimiz, bu metodun temsil ettiği değer olacak.
                //Yani bu metodun geriye değer döndüren bir metod olduğundan bahsediyorum.
                //Bir metodun geriye değer döndürüp döndürmediğini metod isminin solunda yazan yazıdan anlarsınız.
                //Örneğin bu metodun geriye değer döndürdüğünü isminin yanındaki 'string[]' etiketinden anlayabiliriz.
                //Yani bu metod, string karakterlerden oluşan bir dizi döndürüyor.
                //Zaten tam istediğimiz bu değil mi? Kategorilerden oluşan bir dizi göndermek istiyoruz.
                //Fakat bu kodları bir class kullanarak yazdığımız için formumuzdaki araçları doğrudan classtan kontrol edemiyoruz.
                //Şimdi sadece bir dizi oluşturacağız, ve bu diziyi combobox'a atma işlemini sonraya bırakacağız.

                list.Add(Kategori);

            }


            KategoriOkuyucu.Close();
            //SqlDataReader'ımızı kapatıyoruz.


            Baglanti.Baglan.Close();
            //Bağlantımızı kapatıyoruz.

            string[] Kategoriler = new string[list.Count];
            Kategoriler = (string[])list.ToArray(typeof(string));
            //ArrayList'imi diziye çeviriyorum.

            return Kategoriler;
            //Ve geriye dizimi döndürüyorum.

        }

    }
}
