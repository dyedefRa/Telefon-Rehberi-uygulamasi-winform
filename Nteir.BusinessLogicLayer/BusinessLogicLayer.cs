using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nteir.DatabaseLogicLayer;
using Nteir.Entities;

namespace Nteir.BusinessLogicLayer
{
    public class BusinessLogicLayer
    {
        public enum Sonuc
        {
            //Enumu uyarlamak lazım
            Basarili = 1,
            EksikParametre = -1,
            DatabaseSorunu = -2,
            KayitBulunmadi = -3

        }
        //ENUM OLUSTURALIM
        //Metodların geriye dönerkenki degerleri
        //1 başarılı
        //-1 =>Eksik Parametre
        //-2 =>Database katmanındaki sorunlar
        //-3 =>Kayıt  bulunmuyorsa

        public static Kullanici aktifKullanici;
        //Burayı incelemeliyiz
        //AddOrUpdate durumuda incele(Repositoryde)
        private Repository<Kullanici> rep_Kullanici;
        private Repository<Rehber> rep_Rehber;

        public BusinessLogicLayer()
        {
            if (rep_Kullanici == null)
            {
                rep_Kullanici = new Repository<Kullanici>();
            }
            if (rep_Rehber == null)
            {
                rep_Rehber = new Repository<Rehber>();
            }
        }
        #region Rehber İşlemleri
        public int RehberEkle(string Ad, string Soyad, string Tel1, string Tel2, string Tel3, string Email, string WebAdres, string Adres, string Aciklama)
        {
            if (!string.IsNullOrEmpty(Ad) && !string.IsNullOrEmpty(Soyad) && !string.IsNullOrEmpty(Email))
            {
                Rehber temp = new Rehber
                {
                    Ad = Ad,
                    Soyad = Soyad,
                    Tel1 = Tel1,
                    Tel2 = Tel2,
                    Tel3 = Tel3,
                    Email = Email,
                    WebAdres = WebAdres,
                    Adres = Adres,
                    Aciklama = Aciklama

                };
                try
                {
                    return rep_Rehber.Insert(temp);
                }
                catch
                {
                    //Database kısmında hata oluştu
                    return -2;
                }
            }
            //Eksik parametre
            return -1;
        }

        public int RehberDuzenle(Guid id, string Ad, string Soyad, string Tel1, string Tel2, string Tel3, string Email, string WebAdres, string Adres, string Aciklama)
        {
            if (id != null && !string.IsNullOrEmpty(Ad) && !string.IsNullOrEmpty(Soyad) && !string.IsNullOrEmpty(Email))
            {
                var rehber = new Rehber()
                {
                    Id = id,
                    Ad = Ad,
                    Aciklama = Aciklama,
                    Adres = Adres,
                    Email = Email,
                    Soyad = Soyad,
                    Tel1 = Tel1,
                    Tel2 = Tel2,
                    Tel3 = Tel3,
                    WebAdres = WebAdres
                };
                try
                {
                    return rep_Rehber.Update(rehber);
                }
                catch
                {
                    //Database hatası
                    return -2;
                }
            }
            else
            {
                //Eksik parametre
                return -1;
            }
        }

        public int RehberSil(Guid id)
        {
            if (id != null)
            {
                try
                {
                    return rep_Rehber.Delete(rep_Rehber.GetById(id));
                }
                catch
                {
                    //Database hatası
                    return -2;
                }
            }
            else
                //parameter hatasi
                return -1;


        }

        public List<Rehber> RehberListele()
        {
            return rep_Rehber.GetAll();
        }

        public Rehber RehberGetir(Guid id)
        {
            return rep_Rehber.GetById(id);
        }
        #endregion

        public int KullaniciKontrolu(string kullaniciAdi, string Parola)
        {
            if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(Parola))
            {
                var kullanici = rep_Kullanici.GetByExpression(x => x.KullaniciAdi == kullaniciAdi && x.Parola == Parola);
                if (kullanici != null)
                {
                    aktifKullanici = kullanici;
                    return 1;
                }
                else
                {
                    //Kayit yok,Kullanici yok
                    return -3;
                }

            }
            else
            {
                
                //Eksik parametre
                return -1;
            }
        }




    }
}
