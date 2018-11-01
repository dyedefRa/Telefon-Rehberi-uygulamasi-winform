using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nteir.Entities;

namespace Nteir.TelefonRehberi
{
    public partial class AnaForm : Form
    {
        BusinessLogicLayer.BusinessLogicLayer BLL;
        public AnaForm()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer.BusinessLogicLayer();
        }

        public void EklemeTextleriniTemizle()
        {
            txt_ekleAciklama.Clear();
            txt_ekleAd.Clear();
            txt_ekleAdres.Clear();
            txt_ekleEmail.Clear();
            txt_ekleSoyad.Clear();
            txt_ekleTel1.Clear();
            txt_ekleTel2.Clear();
            txt_ekleTel3.Clear();
            txt_ekleWebadres.Clear();
          }
        public void TextleriniTemizle()
        {
            txt_Aciklama.Clear();
            txt_Ad.Clear();
            txt_Adres.Clear();
            txt_Email.Clear();
            txt_Soyad.Clear();
            txt_Tel1.Clear();
            txt_Tel2.Clear();
            txt_Tel3.Clear();
            txt_Web.Clear();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            var deger = BLL.RehberEkle(txt_ekleAd.Text, txt_ekleSoyad.Text, txt_ekleTel1.Text, txt_ekleTel2.Text, txt_ekleTel3.Text, txt_ekleEmail.Text, txt_ekleWebadres.Text, txt_ekleAdres.Text, txt_ekleAciklama.Text);
            if (deger>0)
            {
              
                ListeyiDoldur();
                MessageBox.Show("Kayıt başarıyla eklendi","Bildiri",MessageBoxButtons.OK,MessageBoxIcon.Information);
                EklemeTextleriniTemizle();
               
            }
          else  if (deger==-1)
            {
                MessageBox.Show("Ad , Soyad ve E-mail bölümleri zorunludur. Lütfen doldurup tekrar deneyiniz.");
            }
            else
            {
                MessageBox.Show("Kayıt ekleme sırasında sorun oluştu.Lütfen sonra tekrar deneyiniz...");
            }

        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            var rehberListesi = BLL.RehberListele();
            if (rehberListesi != null)
            {

                list_Liste.DataSource = rehberListesi;
            }
        }

        private void list_Liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            Rehber tiklananDeger = (Rehber)listbox.SelectedItem;
            if (tiklananDeger!=null)
            {
                btn_Duzenle.Tag = tiklananDeger.Id;
                txt_Ad.Text = tiklananDeger.Ad;
                txt_Adres.Text = tiklananDeger.Adres;
                txt_Aciklama.Text = tiklananDeger.Aciklama;
                txt_Email.Text = tiklananDeger.Email;
                txt_Soyad.Text = tiklananDeger.Soyad;
                txt_Tel1.Text = tiklananDeger.Tel1;
                txt_Tel2.Text = tiklananDeger.Tel2;
                txt_Tel3.Text = tiklananDeger.Tel3;
                txt_Web.Text = tiklananDeger.WebAdres;
            }
        }

        private void btn_ekleTemizle_Click(object sender, EventArgs e)
        {
            EklemeTextleriniTemizle();
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            TextleriniTemizle();
        }

        private void btn_Duzenle_Click(object sender, EventArgs e)
        {
            var sonuc = BLL.RehberDuzenle(Guid.Parse(btn_Duzenle.Tag.ToString()), txt_Ad.Text, txt_Soyad.Text, txt_Tel1.Text, txt_Tel2.Text, txt_Tel3.Text, txt_Email.Text, txt_Web.Text, txt_Web.Text, txt_Aciklama.Text);
            if (sonuc>0)
            {
                ListeyiDoldur();
                MessageBox.Show("Kayıt düzenleme işlemi başarıyla tamamlandı", "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (sonuc == -1)
            {
                MessageBox.Show("Ad , Soyad ve E-mail bölümleri zorunludur. Lütfen doldurup tekrar deneyiniz.");
            }
            else
            {
                MessageBox.Show("Kayıt düzenleme işleminde sorun yaşandı.Lütfen sonra tekrar deneyiniz...");
            }
            
    

           

        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            if (btn_Duzenle.Tag!=null)
            {
                var id = Guid.Parse(btn_Duzenle.Tag.ToString());
                var sonuc = BLL.RehberSil(id);
                if (sonuc>0)
                {
                    ListeyiDoldur();
                    MessageBox.Show("Kayıt silme işlemi başarıyla tamamlandı", "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextleriniTemizle();
                }
                else
                {
                    MessageBox.Show("Kayıt silme işleminde sorun yaşandı.Lütfen sonra tekrar deneyiniz...");
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
