using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nteir.BusinessLogicLayer;


namespace Nteir.TelefonRehberi
{
    public partial class Form1 : Form
    { BusinessLogicLayer.BusinessLogicLayer bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BusinessLogicLayer();
        }

       
        private void btn_Giris_Click(object sender, EventArgs e)
        {
          var sonuc=  bll.KullaniciKontrolu(txt_KullaniciAdi.Text, txt_Parola.Text);
            if (sonuc>0)
            {
                AnaForm yeni = new AnaForm();
                yeni.Show();
                this.Hide();
            }
            else if(sonuc==-1)
            {
                MessageBox.Show("Lütfen iki alanıda boş geçmeyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txt_KullaniciAdi.Clear();
                txt_Parola.Clear();
                MessageBox.Show("Giriş başarısız","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
