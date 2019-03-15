using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Kisiler
    {
        public string Ad;
        public string Soyad;
        public string Tc;
        public string No;
    }
    class Program
    {
        public static List<Kisiler> kayitlar = new List<Kisiler>();
        public static string ad, soyad, tc, no;
        public static string islem, silme, cevap, cevap2 = "0", ogrenci_arama, aramasecimi;
        public static string duzenle, adduzen, soyduzen, tcduzen, noduzen, silcevap;
        static void Main(string[] args)
        {
            islem_sec();
        }
        public static void islem_sec()
        {
            Console.Clear();
            Console.Write("\n\n\t\t\t.........İŞLEM SEÇİNİZ.........\n\t\t\t...............................\n\t\t\t    1.Kayıt Ekleme\n\t\t\t    2.Kayıt Arama\n\t\t\t    3.Kayıt Silme\n\t\t\t    4.Kayıt Düzenleme\n\t\t\t    5.Kayıt Listeleme\n\t\t\t    6.Çıkış\n\t\t\t  Seçiminizi Giriniz.. <1-6>\n\t\t\t............................... ");
            islem = Console.ReadLine();
            switch (islem)
            {
                case "1": { Ekle(); break; }
                case "2": { Ara(); break; }
                case "3": { Sil(); break; }
                case "4": { Duzenle(); break; }
                case "5": { Listele(); break; }
                case "6": { Cikis(); break; }
                default: { islem_sec(); break; }
            }
        }
        public static void Ekle()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t\t   - Kayıt Ekleme -\n\t\t\t....................................");
                Console.Write("\t\t\t  Öğrencinin adını giriniz: "); ad = Console.ReadLine();
                Console.Write("\t\t\t  Öğrencinin soyadını giriniz: "); soyad = Console.ReadLine();
                if (ad == null || ad == "" || ad == " " || soyad == null || soyad == "" || soyad == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Hatalı giriş!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
                Console.Write("\t\t\t  Öğrencinin TC Kimlik numarasını giriniz: "); tc = Console.ReadLine();
                Console.Write("\t\t\t  Öğrencinin numarasını giriniz: "); no = Console.ReadLine();
                for (int i = 0; i < kayitlar.Count; i++)
                {
                    if (kayitlar[i].Tc.Contains(tc) || kayitlar[i].No.Contains(no))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\n\n\t\t\t  Tc Kimlik numarası veya Okul numarası sistemde kayıtlı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ReadKey(); Console.ResetColor(); islem_sec();

                    }
                }
                Console.WriteLine("\t\t\t....................................");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t   Kaydınız başarıyla yapıldı.");
                Console.ResetColor();
                Console.WriteLine();
                kayitlar.Add(new Kisiler()
                {
                    Ad = ad,
                    Soyad = soyad,
                    Tc = tc,
                    No = no
                });
                do
                {
                    Console.Write("\t\t\t    Başka kayıt eklemek istiyor musunuz? (E/H): "); cevap = Console.ReadLine(); cevap2 = cevap;
                } while (cevap2 != "h" && cevap2 != "H" && cevap2 != "e" && cevap2 != "E");
            } while (cevap == "E" || cevap == "e");
            islem_sec();
        }
        public static void Ara()
        {
            Console.Clear();
            if (kayitlar.Count != 0)
            {
                Console.Write("\n\n\t\t\t       - Kayıt Arama -\n\t\t\t...........................\n\t\t\t   1.Ad'a göre arama\n\t\t\t   2.Soyad'a göre arama\n\t\t\t   3.TC Kimliğe göre arama\n\t\t\t   4.Numaraya göre arama\n\t\t\t   5.Ana Menü'ye dön\n\t\t\t Seçiminizi Giriniz.. <1-5>\n\t\t\t........................... ");
                aramasecimi = Console.ReadLine();
                switch (aramasecimi)
                {
                    case "1": { Console.WriteLine(); Adara(); break; }
                    case "2": { Console.WriteLine(); Soyara(); break; }
                    case "3": { Console.WriteLine(); Tcara(); break; }
                    case "4": { Console.WriteLine(); Noara(); break; }
                    case "5": { islem_sec(); break; }
                    default: { Ara(); break; }
                }
            }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
        }
        public static void Adara()
        {
            Console.Write("\t\t\tAramak istediğiniz kişinin adını yazınız: "); ogrenci_arama = Console.ReadLine(); Console.Clear();
            if (ogrenci_arama == null || ogrenci_arama == "" || ogrenci_arama == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
            Console.WriteLine("\n\n\t\t\t\t=======Kayıtlar Listeleniyor=======\n\t\tAd\t\tSoyad\t\tTC Kimlik\t\tNumara\n\t\t================================================================");
            for (int i = 0; i < kayitlar.Count; i++)
            {
                if (kayitlar[i].Ad.Contains(ogrenci_arama))
                    Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
            }
            Console.WriteLine("\t\t================================================================");
            tekrarara();
        }
        public static void Soyara()
        {
            Console.Write("\t\t\tAramak istediğiniz kişinin soyadını yazınız: "); ; ogrenci_arama = Console.ReadLine(); Console.Clear();
            if (ogrenci_arama == null || ogrenci_arama == "" || ogrenci_arama == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
            Console.WriteLine("\n\n\t\t\t\t=======Kayıtlar Listeleniyor=======\n\t\tAd\t\tSoyad\t\tTC Kimlik\t\tNumara\n\t\t================================================================");
            for (int i = 0; i < kayitlar.Count; i++)
            {
                if (kayitlar[i].Soyad.Contains(ogrenci_arama))
                    Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
            }
            Console.WriteLine("\t\t================================================================");
            tekrarara();
        }
        public static void Tcara()
        {
            Console.Write("\t\t\tAramak istediğiniz kişinin TC Kimlik numarasını yazınız: "); ogrenci_arama = Console.ReadLine(); Console.Clear();
            if (ogrenci_arama == null || ogrenci_arama == "" || ogrenci_arama == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
            Console.WriteLine("\n\n\t\t\t\t=======Kayıtlar Listeleniyor=======\n\t\tAd\t\tSoyad\t\tTC Kimlik\t\tNumara\n\t\t================================================================");
            for (int i = 0; i < kayitlar.Count; i++)
            {
                if (kayitlar[i].Tc.Contains(ogrenci_arama))
                    Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
            }
            Console.WriteLine("\t\t================================================================");
            tekrarara();
        }
        public static void Noara()
        {
            Console.Write("\t\t\tAramak istediğiniz kişinin numarasını yazınız: "); ogrenci_arama = Console.ReadLine(); Console.Clear();
            if (ogrenci_arama == null || ogrenci_arama == "" || ogrenci_arama == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
            Console.WriteLine("\n\n\t\t\t\t=======Kayıtlar Listeleniyor=======\n\t\tAd\t\tSoyad\t\tTC Kimlik\t\tNumara\n\t\t================================================================");
            for (int i = 0; i < kayitlar.Count; i++)
            {
                if (kayitlar[i].No.Contains(ogrenci_arama))
                    Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
            }
            Console.WriteLine("\t\t================================================================");
            tekrarara();
        }
        public static void Sil()
        {
            Console.Clear();
            if (kayitlar.Count != 0)
            {
                int varmi = 0;
                Console.Write("\n\n\t\t\t       - Kayıt Silme -\n\t\t\t..............................\n\t\t\tSileceğiniz kaydı arayınız: "); silme = Console.ReadLine();
                Console.Clear();
                if (silme == null || silme == "" || silme == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
                for (int i = 0; i < kayitlar.Count; i++)
                {
                    if (kayitlar[i].Ad.Contains(silme) || kayitlar[i].Soyad.Contains(silme) || kayitlar[i].Tc.Contains(silme) || kayitlar[i].No.Contains(silme))
                    {
                        Console.WriteLine("\n\n\t\t\t=======Kayıtlar Listeleniyor=======\n\t\t\t===================================\n");
                        varmi = 0;
                        Sil2();

                    }
                    else varmi++;
                }
                if (varmi != 0) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
            }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
        }
        public static void Sil2()
        {
            for (int i = 0; i < kayitlar.Count; i++)
            {
                if (kayitlar[i].Ad.Contains(silme) || kayitlar[i].Soyad.Contains(silme) || kayitlar[i].Tc.Contains(silme) || kayitlar[i].No.Contains(silme))
                {
                    Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
                    break;
                }
            }
            Console.WriteLine("\t\t\t===================================");
            do
            {
                Console.Write("\t\t\tYukarıdaki kayıt silinsin mi? (E/H): "); silcevap = Console.ReadLine();
            } while (silcevap != "h" && silcevap != "H" && silcevap != "e" && silcevap != "E");
            if (silcevap == "E" || silcevap == "e")
            {
                for (int i = 0; i < kayitlar.Count; i++)
                {
                    if (kayitlar[i].Ad.Contains(silme) || kayitlar[i].Soyad.Contains(silme) || kayitlar[i].Tc.Contains(silme) || kayitlar[i].No.Contains(silme))
                        kayitlar.RemoveAt(i);
                }
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\t\t\t   Kayıt başarıyla silindi!\n"); Console.ResetColor();
            }
            else islem_sec();
            tekrarsil();
        }
        public static void tekrarsil()
        {
            do
            {
                Console.Write("\t\t\t    Başka kayıt silmek istiyor musunuz? (E/H): "); cevap = Console.ReadLine(); cevap2 = cevap;
            } while (cevap2 != "h" && cevap2 != "H" && cevap2 != "e" && cevap2 != "E");
            if (cevap2 == "e" || cevap2 == "E") Sil();
            else islem_sec();
        }
        public static void tekrarara()
        {
            do
            {
                Console.Write("\t\t\t    Tekrar arama yapmak istiyor musunuz? (E/H): "); cevap = Console.ReadLine(); cevap2 = cevap;
            } while (cevap2 != "h" && cevap2 != "H" && cevap2 != "e" && cevap2 != "E");
            if (cevap2 == "e" || cevap2 == "E") Ara();
            else islem_sec();
        }
        public static void Duzenle()
        {
            Console.Clear();
            if (kayitlar.Count != 0)
            {
                Console.Write("\n\n\t\t\t       - Kayıt Düzenleme -\n\t\t\t..................................\n\t\t\tDüzenleyeceğiniz kaydı arayınız: "); duzenle = Console.ReadLine();
                if (duzenle == null || duzenle == "" || duzenle == " ") { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
                Console.WriteLine("\t\t\t..................................\n");
                for (int i = 0; i < kayitlar.Count; i++)
                {
                    if (kayitlar[i].Ad.Contains(duzenle) || kayitlar[i].Soyad.Contains(duzenle) || kayitlar[i].Tc.Contains(duzenle) || kayitlar[i].No.Contains(duzenle))
                    {
                        Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
                        Duzenle2();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec();

            }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
        }
        public static void Duzenle2()
        {
            Console.WriteLine("\t\t\t..................................");
            for (int i = 0; i < kayitlar.Count; i++)
            {
                if (kayitlar[i].Ad.Contains(duzenle) || kayitlar[i].Soyad.Contains(duzenle) || kayitlar[i].Tc.Contains(duzenle) || kayitlar[i].No.Contains(duzenle))
                {
                    Console.Write("\t\t\t   Yeni Ad: "); adduzen = Console.ReadLine();
                    if (adduzen == "" || adduzen == null || adduzen == " ") { }
                    else
                    {
                        kayitlar[i].Ad = adduzen;
                    }
                    Console.Write("\t\t\t   Yeni Soyad: "); soyduzen = Console.ReadLine();
                    if (soyduzen == "" || soyduzen == null || soyduzen == " ") { }
                    else
                    {
                        kayitlar[i].Soyad = soyduzen;
                    }
                    Console.Write("\t\t\t   Yeni Tc Kimlik: "); tcduzen = Console.ReadLine();
                    if (tcduzen == "" || tcduzen == null || tcduzen == " ") { }
                    else
                    {
                        kayitlar[i].Tc = tcduzen;
                    }
                    Console.Write("\t\t\t   Yeni Numara: "); noduzen = Console.ReadLine();
                    if (noduzen == "" || noduzen == null || noduzen == " ") { }
                    else
                    {
                        kayitlar[i].No = noduzen;
                    }
                    break;
                }
            }
            do
            {
                Console.Write("\t\t\t................................\n\t\t\t    Başka kayıt düzenlemek istiyor musunuz? (E/H): "); cevap = Console.ReadLine(); cevap2 = cevap;
            } while (cevap2 != "h" && cevap2 != "H" && cevap2 != "e" && cevap2 != "E");
            if (cevap == "e" || cevap == "E") Duzenle();
            else islem_sec();
        }
        public static void Listele()
        {
            Console.Clear();
            if (kayitlar.Count != 0)
            {
                Console.WriteLine("\n\n\t\t\t\t=======Kayıtlar Listeleniyor=======\n\t\tAd\t\tSoyad\t\tTC Kimlik\t\tNumara\n\t\t================================================================");
                for (int i = 0; i < kayitlar.Count; i++)
                {
                    Console.WriteLine("\t\t" + kayitlar[i].Ad + "\t\t" + kayitlar[i].Soyad + "\t\t" + kayitlar[i].Tc + "\t\t" + kayitlar[i].No + "\n");
                }
                Console.WriteLine("\t\t================================================================");
                Console.Write("\t\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ReadKey(); islem_sec();
            }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.Write("\n\n\n\t\t\t  Kayıt bulunamadı!\n \n\t\t\tAna menüye dönmek için bir tuşa basınız."); Console.ResetColor(); Console.ReadKey(); islem_sec(); }
        }
        public static void Cikis()
        {
            Environment.Exit(0);
        }
    }
}
