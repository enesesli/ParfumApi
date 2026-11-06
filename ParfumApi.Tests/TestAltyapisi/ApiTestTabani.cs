namespace ParfumApi.Tests.TestAltyapisi;

// Entegrasyon testlerinin ortak yardımcıları: ürün ekleme, sipariş verme, ödeme...
// Her test kendi ürününü oluşturur; böylece testler birbirinin stoğunu etkilemez.
public abstract class ApiTestTabani : IClassFixture<ApiFabrikasi>
{
    public const string BasariliKart = "4242424242424242";
    public const string ReddedilenKart = "4000000000000002";
    public const string LimitiYetersizKart = "4000000000009995";

    protected readonly HttpClient Istemci;
    private string? _adminTokeni;

    protected ApiTestTabani(ApiFabrikasi fabrika)
    {
        Istemci = fabrika.CreateClient();
    }

    protected static TeslimatBilgisi Teslimat(string? eposta = null) => new()
    {
        AdSoyad = "Test Müşteri",
        Eposta = eposta ?? $"musteri-{Guid.NewGuid():N}@ornek.com",
        Telefon = "0555 111 22 33",
        Adres = "Test mahallesi, deneme sokak no 1",
        Sehir = "Konya",
    };

    protected async Task<string> AdminTokeni()
    {
        if (_adminTokeni is not null) return _adminTokeni;

        var yanit = await Istemci.PostAsJsonAsync("/api/auth/giris", new GirisDto
        {
            KullaniciAdi = ApiFabrikasi.AdminKullaniciAdi,
            Sifre = ApiFabrikasi.AdminSifre,
        });
        yanit.EnsureSuccessStatusCode();
        var sonuc = await yanit.Content.ReadFromJsonAsync<GirisSonucDto>();
        return _adminTokeni = sonuc!.Token;
    }

    protected async Task<HttpRequestMessage> AdminIstegi(HttpMethod yontem, string adres, object? govde = null)
    {
        var istek = new HttpRequestMessage(yontem, adres);
        istek.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await AdminTokeni());
        if (govde is not null) istek.Content = JsonContent.Create(govde);
        return istek;
    }

    // Yönetici olarak test için yeni bir parfüm ekler ve numarasını döndürür
    protected async Task<int> UrunEkle(int stok, decimal fiyat = 1000m)
    {
        var istek = await AdminIstegi(HttpMethod.Post, "/api/parfumler", new ParfumKaydetDto
        {
            Ad = $"Test Parfümü {Guid.NewGuid():N}"[..30],
            Aciklama = "Test için eklendi.",
            Fiyat = fiyat,
            HacimMl = 50,
            Cinsiyet = "Unisex",
            Stok = stok,
            MarkaId = 1,
            KokuAilesi = "Ferah",
            Konsantrasyon = "Eau de Parfum",
            Renk = "#aabbcc",
        });
        var yanit = await Istemci.SendAsync(istek);
        Assert.Equal(HttpStatusCode.Created, yanit.StatusCode);
        var urun = await yanit.Content.ReadFromJsonAsync<ParfumDto>();
        return urun!.Id;
    }

    protected async Task<int> Stok(int parfumId)
    {
        var urun = await Istemci.GetFromJsonAsync<ParfumDto>($"/api/parfumler/{parfumId}");
        return urun!.Stok;
    }

    protected Task<HttpResponseMessage> SiparisIstegi(object istek) =>
        Istemci.PostAsJsonAsync("/api/siparisler", istek);

    protected async Task<SiparisDto> SiparisVer(params (int ParfumId, int Adet)[] kalemler)
    {
        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = Teslimat(),
            Kalemler = kalemler.Select(k => new SepetKalemiIstegi { ParfumId = k.ParfumId, Adet = k.Adet }).ToList(),
        });
        Assert.Equal(HttpStatusCode.Created, yanit.StatusCode);
        return (await yanit.Content.ReadFromJsonAsync<SiparisDto>())!;
    }

    protected Task<HttpResponseMessage> KartlaOde(SiparisDto siparis, string kartNo = BasariliKart, string sonKullanma = "12/35") =>
        Istemci.PostAsJsonAsync($"/api/siparisler/{siparis.SiparisNo}/odeme/kart", new KartOdemeIstegi
        {
            Eposta = siparis.Eposta,
            KartSahibi = "Test Müşteri",
            KartNo = kartNo,
            SonKullanma = sonKullanma,
            Cvc = "123",
        });

    protected Task<SiparisDto?> SiparisiGetir(SiparisDto siparis) =>
        Istemci.GetFromJsonAsync<SiparisDto>(
            $"/api/siparisler/{siparis.SiparisNo}?eposta={Uri.EscapeDataString(siparis.Eposta)}");

    protected async Task<HttpResponseMessage> DurumDegistir(int siparisId, string durum) =>
        await Istemci.SendAsync(await AdminIstegi(HttpMethod.Put, $"/api/siparisler/{siparisId}/durum",
            new DurumGuncelleIstegi { Durum = durum }));
}
