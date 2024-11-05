using System;
using System.Collections.Generic;

class Program
{
    // Müşteri bilgilerini tutacak sınıfı oluşturuyoruz
    class Musteri
    {
        public string Ad { get; set; }  // Müşterinin adı
        public int Oncelik { get; set; } // Müşterinin öncelik seviyesi: 1 (Yüksek) 2 (Orta) 3 (Düşük)

        // Yapıcı metotumuzu oluşturuyoruz
        public Musteri(string ad, int oncelik)
        {
            Ad = ad;
            Oncelik = oncelik;
        }
    }

    // Kuyruk sınıfımızı oluşturuyoruz
    class Kuyruk
    {
        private Queue<Musteri> yuksekOncelikli = new Queue<Musteri>(); // Yüksek öncelikli kuyruk
        private Queue<Musteri> ortaOncelikli = new Queue<Musteri>();   // Orta öncelikli kuyruk
        private Queue<Musteri> dusukOncelikli = new Queue<Musteri>();  // Düşük öncelikli kuyruk

        // Müşteri ekleme metodumuzu oluşturuyoruz
        public void Ekle(Musteri musteri)
        {
            // Müşterinin öncelik seviyesine göre kuyruğa ekliyoruz
            switch (musteri.Oncelik)
            {
                case 1:
                    yuksekOncelikli.Enqueue(musteri); // Yüksek öncelikli kuyruğa ekle
                    break;
                case 2:
                    ortaOncelikli.Enqueue(musteri);   // Orta öncelikli kuyruğa ekle
                    break;
                case 3:
                    dusukOncelikli.Enqueue(musteri);  // Düşük öncelikli kuyruğa ekle
                    break;
            }
        }

        // Müşteri alma metodumuzu oluşturuyoruz
        public Musteri Al()
        {
            // En yüksek öncelikli kuyruktan müşteri alma işlemi
            if (yuksekOncelikli.Count > 0) return yuksekOncelikli.Dequeue(); // Yüksek öncelikli kuyruktan al
            if (ortaOncelikli.Count > 0) return ortaOncelikli.Dequeue();   // Orta öncelikli kuyruktan al
            if (dusukOncelikli.Count > 0) return dusukOncelikli.Dequeue(); // Düşük öncelikli kuyruktan al
            return null; // Tüm kuyruklar boşsa null döndür
        }

        // Kuyruktaki tüm müşterileri yazdırma metodumuzu oluşturuyoruz
        public void Yazdir()
        {
            Console.WriteLine("Kuyruktaki Müşteriler:");
            YazdirKuyruk(yuksekOncelikli, "Yüksek Öncelikli"); // Yüksek öncelikli kuyruğu yazdır
            YazdirKuyruk(ortaOncelikli, "Orta Öncelikli");     // Orta öncelikli kuyruğu yazdır
            YazdirKuyruk(dusukOncelikli, "Düşük Öncelikli");   // Düşük öncelikli kuyruğu yazdır
        }

        // Belirli bir kuyruktaki müşterileri yazdırma metodumuz
        private void YazdirKuyruk(Queue<Musteri> kuyruk, string kuyrukAdi)
        {
            Console.WriteLine($"{kuyrukAdi} Müşteriler:"); // Kuyruk adını yazdırıyoruz
            foreach (var musteri in kuyruk)
            {
                Console.WriteLine($"- {musteri.Ad}"); // Müşteri adını yazdırıyoruz
            }
        }
    }

    // Main metodumuz
    static void Main(string[] args)
    {
        Kuyruk kuyruk = new Kuyruk(); // Yeni bir kuyruk oluşturuyoruz
        string devam; // Kullanıcının devam edip etmeyeceğini soracağımız değişken

        // Kullanıcıdan müşteri bilgilerini alıyoruz
        do
        {
            Console.Write("Müşterinin adını girin: "); // Müşteri adını istiyoruz
            string ad = Console.ReadLine(); // Kullanıcıdan müşteri adını alıyoruz

            Console.Write("Müşterinin öncelik seviyesini girin (1: Yüksek, 2: Orta, 3: Düşük): "); // Öncelik seviyesini istiyoruz
            int oncelik = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan öncelik seviyesini alıyoruz

            kuyruk.Ekle(new Musteri(ad, oncelik)); // Müşteriyi kuyruğa ekliyoruz

            Console.Write("Başka bir müşteri eklemek istiyor musunuz? (E/H): "); // Devam etmek isteyip istemediğini soruyoruz
            devam = Console.ReadLine().ToUpper(); // Kullanıcının cevabı küçük harf olabilir bu yüzden büyük harfe çeviriyoruz

        } while (devam == "E"); // Kullanıcı "E" (evet) dedikçe döngü devam edecek

        kuyruk.Yazdir(); // Kuyruktaki tüm müşterileri göster

        // Müşteri alma işlemleri
        Console.WriteLine("\nİlk müşteri alınıyor: " + kuyruk.Al()?.Ad); // İlk müşteriyi al ve adını yazdır

        kuyruk.Yazdir(); // Güncel kuyruk durumunu yazdır
    }
}
