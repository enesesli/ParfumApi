using System.Security.Cryptography;
using ParfumApi.Models;

namespace ParfumApi.Services.Odeme;

public record KriptoFatura(string Para, decimal Tutar, decimal Kur, string Adres, DateTime SonTarih);

// Kripto ödeme sözleşmesi. Gerçek bir sistemde fatura oluşturulur, sonra blokzinciri izlenerek
// o adrese doğru tutarın gelip gelmediğine bakılır.
public interface IKriptoOdemeServisi
{
    bool SimulasyonMu { get; }
    KriptoFatura FaturaOlustur(Siparis siparis, string para);
}

// UYARI: Türkiye'de kripto varlıklarla ödeme 2021'den beri yasaktır
// (Ödemelerde Kripto Varlıkların Kullanılmamasına Dair Yönetmelik).
// Bu sınıf yalnızca akışı öğrenmek için bir simülasyondur: gerçek cüzdan, borsa ya da blokzinciri yoktur.
public class SimuleKriptoOdemeServisi : IKriptoOdemeServisi
{
    private static readonly TimeSpan FaturaSuresi = TimeSpan.FromMinutes(15);

    // 1 birim kripto kaç TL? Temsili sabit kurlar. Gerçekte fatura anında bir kur servisinden alınır.
    private static readonly Dictionary<string, (decimal Kur, int Ondalik)> Kurlar = new()
    {
        ["USDT"] = (42m, 2),
        ["BTC"] = (4_200_000m, 8),
        ["ETH"] = (150_000m, 6),
    };

    public bool SimulasyonMu => true;

    public KriptoFatura FaturaOlustur(Siparis siparis, string para)
    {
        var (kur, ondalik) = Kurlar[para];

        // Kur fatura anında sabitlenir; müşteri bu tutarı süre dolmadan göndermelidir
        var tutar = Math.Round(siparis.Toplam / kur, ondalik, MidpointRounding.AwayFromZero);

        // Hiçbir ağda geçerli olmayan, açıkça "DEMO" yazan bir adres
        var adres = $"DEMO-{para}-{RandomNumberGenerator.GetHexString(24, lowercase: true)}";

        return new KriptoFatura(para, tutar, kur, adres, DateTime.UtcNow.Add(FaturaSuresi));
    }
}
