using System;
using System.IO;

class Ev
{
    public string Tip { get; set; }
    public string Adres { get; set; }
    public int OdaSayisi { get; set; }
    public int Kira { get; set; }
    public int Kat { get; set; }
    public int Alan { get; set; }
    public int Depozito { get; set; }

    public Ev(string tip, string adres, int odaSayisi, int kira, int kat, int alan, int depozito)
    {
        Tip = tip;
        Adres = adres;
        OdaSayisi = odaSayisi;
        Kira = kira;
        Kat = kat;
        Alan = alan;
        Depozito = depozito;
    }

    public override string ToString()
    {
        return $"{Tip} Ev\nAdres: {Adres}\nOda Sayısı: {OdaSayisi}\nKira: {Kira}\nKat: {Kat}\nAlan: {Alan}\nDepozito: {Depozito}\n";
    }
}

class Program
{
    static void EvEkle()
    {
        Console.Write("Ev tipini girin (kiralık/satılık): ");
        string tip = Console.ReadLine().Trim().ToLower();

        if (tip != "kiralık" && tip != "satılık")
        {
            Console.WriteLine("Geçersiz ev tipi!");
            return;
        }

        Console.Write("Adresi girin: ");
        string adres = Console.ReadLine().Trim();

        Console.Write("Oda sayısını girin: ");
        int odaSayisi;
        if (!int.TryParse(Console.ReadLine().Trim(), out odaSayisi))
        {
            Console.WriteLine("Geçersiz oda sayısı!");
            return;
        }

        Console.Write("Kira bedelini girin: ");
        int kira;
        if (!int.TryParse(Console.ReadLine().Trim(), out kira))
        {
            Console.WriteLine("Geçersiz kira bedeli!");
            return;
        }

        Console.Write("Kat numarasını girin: ");
        int kat;
        if (!int.TryParse(Console.ReadLine().Trim(), out kat))
        {
            Console.WriteLine("Geçersiz kat numarası!");
            return;
        }

        Console.Write("Alanı girin: ");
        int alan;
        if (!int.TryParse(Console.ReadLine().Trim(), out alan))
        {
            Console.WriteLine("Geçersiz alan!");
            return;
        }

        Console.Write("Depozito miktarını girin: ");
        int depozito;
        if (!int.TryParse(Console.ReadLine().Trim(), out depozito))
        {
            Console.WriteLine("Geçersiz depozito miktarı!");
            return;
        }

        Ev ev = new Ev(tip, adres, odaSayisi, kira, kat, alan, depozito);

        using (StreamWriter writer = new StreamWriter("ev_ilanlari.txt", true))
        {
            writer.WriteLine(ev.ToString());
        }

        Console.WriteLine("Ev bilgileri başarıyla kaydedildi.");
    }

    static void EvleriListele()
    {
        try
        {
            using (StreamReader reader = new StreamReader("ev_ilanlari.txt"))
            {
                Console.WriteLine("\n--- Ev İlanları ---");
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Henüz kaydedilmiş ev ilanı bulunmamaktadır.");
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n1. Ev Ekle");
            Console.WriteLine("2. Evleri Listele");
            Console.WriteLine("3. Çıkış");

            Console.Write("Yapmak istediğiniz işlemi seçin (1/2/3): ");
            string secim = Console.ReadLine().Trim();

            switch (secim)
            {
                case "1":
                    EvEkle();
                    break;
                case "2":
                    EvleriListele();
                    break;
                case "3":
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçenek! Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
