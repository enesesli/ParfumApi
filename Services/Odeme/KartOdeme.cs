using ParfumApi.Models;

namespace ParfumApi.Services.Odeme;

public record KartBilgisi(string KartSahibi, string KartNo, string SonKullanma, string Cvc);

public record OdemeSonucu(bool Basarili, string? Referans, string? HataMesaji);

// Kartla ödeme alan her sağlayıcı bu sözleşmeye uyar.
// Bugün sahte servis, ileride iyzico test ortamı: controller hangisinin çalıştığını bilmez.
public interface IKartOdemeServisi
{
    string SaglayiciAdi { get; }
    Task<OdemeSonucu> Ode(Siparis siparis, KartBilgisi kart);
}

// Gerçek bir ödeme kuruluşunun test ortamını taklit eder.
// Sadece aşağıdaki test kartlarını kabul eder; kart bilgisi hiçbir yere yazılmaz.
public class SahteKartOdemeServisi : IKartOdemeServisi
{
    public static readonly Dictionary<string, string?> TestKartlari = new()
    {
        ["4242424242424242"] = null,                                   // başarılı
        ["4000000000000002"] = "Kart, bankası tarafından reddedildi.",
        ["4000000000009995"] = "Kartın limiti yetersiz.",
    };

    public string SaglayiciAdi => "Sahte ödeme (simülasyon)";

    public async Task<OdemeSonucu> Ode(Siparis siparis, KartBilgisi kart)
    {
        // Bankayla haberleşiyormuş gibi kısa bir bekleme
        await Task.Delay(700);

        var numara = new string(kart.KartNo.Where(char.IsDigit).ToArray());

        if (!TestKartlari.TryGetValue(numara, out var hata))
            return new OdemeSonucu(false, null, "Bu bir simülasyondur; sadece test kartları kabul edilir.");

        if (hata is not null)
            return new OdemeSonucu(false, null, hata);

        var referans = "SAHTE-" + Guid.NewGuid().ToString("N")[..12].ToUpperInvariant();
        return new OdemeSonucu(true, referans, null);
    }
}
