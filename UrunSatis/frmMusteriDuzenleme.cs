using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//C# üzerinden sql komutlarını yazabilmemiz için bu kütüphaneyi içe aktarmamız gerekiyor.

namespace UrunSatis
{
    public partial class frmMusteriDuzenleme : Form
    {
        public frmMusteriDuzenleme()
        {
            InitializeComponent();
        }
        void HerseyiTemizle()
        {
            txtAd.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtId.Clear();
        }
        void HerseyiListele()
        {
            Connection Baglanti = new Connection();

            Baglanti.Baglan.Open();

            string Sorgu = "SELECT * FROM Musteriler";

            SqlCommand Komut = new SqlCommand(Sorgu, Baglanti.Baglan);

            SqlDataAdapter Bilgi = new SqlDataAdapter(Komut);

            DataTable BilgininTabloHali = new DataTable();

            Bilgi.Fill(BilgininTabloHali);

            dtMusteri.DataSource = BilgininTabloHali;

            dtMusteri.ReadOnly = true;

            Baglanti.Baglan.Close();
            /* Formumuz yüklendiğinde veya herhangi bir kaydı sildiğimizde veya güncellediğimizde, güncel olan kayıtların listelenmesi için
            * kullanacağımız metod. Tam şu an, evet evet! Tam şuan geçerli olan kayıtları listeler. Örneğin A sütununu değiştirdikten sonra
            * hemen değişmiş sütun karşınıza çıkacak bu metod sayesinde!*/
        }
        private void frmMusteriDuzenleme_Load(object sender, EventArgs e)
        {
            HerseyiListele();

            dtMusteri.Columns[0].HeaderText = "ID";
            dtMusteri.Columns[1].HeaderText = "Ad";
            dtMusteri.Columns[2].HeaderText = "Telefon";
            dtMusteri.Columns[3].HeaderText = "Adres";
            dtMusteri.Columns[4].HeaderText = "Email";
            dtMusteri.Columns[5].HeaderText = "Kayıt Tarih";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dtMusteri.CurrentRow.Cells["MusteriId"].Value.ToString();
            //Datagridview'de bir satıra çift tıkladığımızda o satırın MusteriId değeri, txtId textboxımıza gönderilecek.
            //Peki neden yaptık bunu?
            //Bunu yaparak txtId textboxının yazısını değiştirdik değil mi?
            //Ve txtId textboxının yazısı değişirse diye bir olay ekleyeceğiz ve o olayda da, bu textbox'a gelen id'ye sahip
            //kaydın bütün verilerini tek tek diğer textboxlarda göstereceğiz.
        }

        private void txtId_TextChanged_1(object sender, EventArgs e)
        {
            //Eğer Id isimli, müşeterimizin id değeri için özel olarak ayırdığımız textbox herhangi bir sebepten ötürü değişirse,
            //aşağıdaki kodlar çalışacaktır. Bu textbox, belirttiğim datagridview'in bir satırına bir kere tıklayarak da değişebilir.

            Connection Baglanti = new Connection();
            //Connection sınıfımızdan Baglanti nesnesini türeterek bağlantımızla bir nevi tanışıyoruz.

            try
            {
                Baglanti.Baglan.Open();
                //Bağlantımızı açıyoruz.

                SqlCommand Komut = new SqlCommand("SELECT * FROM Musteriler WHERE MusteriId LIKE @id", Baglanti.Baglan);

                Komut.Parameters.AddWithValue("@id", txtId.Text + "%");
                //Id textboxımızdaki id değeriyle başlayan tüm kayıtları listeliyoruz.

                SqlDataReader Okuyucu = Komut.ExecuteReader();
                //Listelenen bilgiyi ayrıntılı olarak kullanabilmek için Okuyucu ismini verdiğimiz SqlDataReader'a atıyoruz.

                while (Okuyucu.Read())
                //Okuyucumuzun okuduğu sürece, istediğimiz kaydı bulduğu sürece,
                {
                    txtAd.Text = Okuyucu["MusteriAd"].ToString();

                    txtTelefon.Text = Okuyucu["MusteriTelefon"].ToString();

                    txtAdres.Text = Okuyucu["MusteriAdres"].ToString();

                    txtEmail.Text = Okuyucu["MusteriEmail"].ToString();
                    //Bulduğu verileri teker teker araçlarımıza gönderdik ve başarıyla görüntüledik.
                }

                Okuyucu.Close();
                //Okuyucumuzu kapattık. Kapatmazsak hata verebilir.

                Baglanti.Baglan.Close();
                //Bağlantımızı kapattık.
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //Eğer bir hata alırsak, bu komut zinciri yardımıyla program patlamadan hata mesajını MessageBox yardımıyla alacağız.

            if (txtId.Text == "")
                HerseyiTemizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            HerseyiTemizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Programımızın daha okunabilir ve anlaşılır olması için, textboxlarımızdan gelen verilerimizi değişkenlerimize attık.
            string Ad = txtAd.Text;
            string Adres = txtAdres.Text;
            string Telefon = txtTelefon.Text;
            string Email = txtEmail.Text;

            Connection Baglanti = new Connection();

            Baglanti.Baglan.Open();
            //Bağlantımızı açtık.

            SqlCommand Komut = new SqlCommand("UPDATE Musteriler SET MusteriAd=@ad,MusteriTelefon=@telefon,MusteriAdres=@adres,MusteriEmail=@email WHERE MusteriId=@id", Baglanti.Baglan);
             //Güncelleme işlemi için yazmamız gereken sql sorgusunu yazdık.

            Komut.Parameters.AddWithValue("@ad", Ad);
            //@ad parametresini, Ad değişkenimdeki değerle doldur.
            Komut.Parameters.AddWithValue("@telefon", Telefon);
            //@telefon parametresini, Telefon değişkenimdeki değerle doldur.
            Komut.Parameters.AddWithValue("@adres", Adres);
            //@adres parametresini, Adres değişkenimdeki değerle doldur.
            Komut.Parameters.AddWithValue("@email", Email);
            //@email parametresini, Email değişkenimdeki değerle doldur.

            Komut.Parameters.AddWithValue("@id", dtMusteri.CurrentRow.Cells["MusteriId"].Value.ToString());
            //@id parametresini, datagridview'de seçilmiş olan satırın MusteriId değeriyle doldur!


            Komut.ExecuteNonQuery();
            //Sorgumuzu yürüttük.

            Baglanti.Baglan.Close();
            //Bağlantımızı kapattık.

            MessageBox.Show("Müşteri güncelleme işlemi başarıyla tamamlandı !!");

            HerseyiListele();

            HerseyiTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Burada ise datagridview'de bir kere tıklamamız yeterli olacak şekilde seçtiğimiz satırın silme işlemini gerçekleştiriyoruz.

            Connection Baglanti = new Connection();

            Baglanti.Baglan.Open();
            //Bağlantımızı açtık.

            SqlCommand Komut = new SqlCommand("DELETE FROM Musteriler WHERE MusteriId=@id", Baglanti.Baglan);
            //Sorgumuzu yazdık.

            Komut.Parameters.AddWithValue("@id", dtMusteri.CurrentRow.Cells["MusteriId"].Value.ToString());
            //Sorgumuzun içindeki @id değerini, datagridview'de seçilmiş olan satırla dolduracağımızı belirttik.

            Komut.ExecuteNonQuery();
            //Komudumuzu yürüttük.

            Baglanti.Baglan.Close();
            //Ve bağlantımızı kapattık.

            MessageBox.Show("Müşteri silme işlemi başarıyla tamamlandı !!");

            HerseyiListele();

            HerseyiTemizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Connection Baglanti = new Connection();

            Baglanti.Baglan.Open();

            SqlCommand Komut = new SqlCommand("SELECT * FROM Musteriler WHERE MusteriId LIKE @id", Baglanti.Baglan);

            Komut.Parameters.AddWithValue("@id", txtArama.Text + "%");
            //Arama textbox'ına yazdığımız değere sahip kaydı listeledik.

            SqlDataAdapter Bilgi = new SqlDataAdapter(Komut);
            //Bu kaydı SqlDataAdapter'e attık çünkü bilgimizi datagridview'de görüntülemek için DataTable'a çevirmeye ihtiyacımız var.
            //DataTable'a çevirmek içinse SqlDataAdapter'e ihtiyacımız var. Komuttan görüntülenen veriler Bilgi isimli SqlDataAdapter'imize
            //yönlendirildi.

            DataTable BilgininTabloHali = new DataTable();
            //Boş bir tablo oluşturuyoruz. Bundan sonraki adımda dolduracağız.

            Bilgi.Fill(BilgininTabloHali);
            //Boş tablomuzu Bilgi'deki bilgilerle dolduruyoruz.

            dtMusteri.DataSource = BilgininTabloHali;
            //Nihayet tablomuz oluşturulduğunda, bu tabloyu datagridview'de görüntüleyebiliriz.

            Baglanti.Baglan.Close();
        }
    }
}
