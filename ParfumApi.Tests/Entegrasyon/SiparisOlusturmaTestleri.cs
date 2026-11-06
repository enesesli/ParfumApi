namespace ParfumApi.Tests.Entegrasyon;

// Entegrasyon testi: API'yi gerçekten ayağa kaldırıp (geçici bir SQLite dosyasıyla) HTTP üzerinden konuşur.
public class SiparisOlusturmaTestleri(ApiFabrikasi fabrika) : ApiTestTabani(fabrika)
{
    [Fact]
    public async Task Fiyat_sunucuda_hesaplanir_istemcinin_gonderdigi_fiyat_dikkate_alinmaz()
    {
        var urun = await UrunEkle(stok: 5, fiyat: 1000m);

        // Kötü niyetli bir istemci isteğe "fiyat" alanı ekleyip ürünü 1 TL'ye almaya çalışıyor
        var yanit = await SiparisIstegi(new
        {
            teslimat = Teslimat(),
            kalemler = new[] { new { parfumId = urun, adet = 1, fiyat = 1m } },
            toplam = 1m,
        });

        Assert.Equal(HttpStatusCode.Created, yanit.StatusCode);
        var siparis = await yanit.Content.ReadFromJsonAsync<SiparisDto>();
        Assert.Equal(1000m, siparis!.Kalemler[0].BirimFiyat);
        Assert.Equal(1150m, siparis.Toplam);
    }

    [Theory]
    [InlineData(1, 150)]   // 1000 TL -> kargo ücretli
    [InlineData(2, 0)]     // 2000 TL -> kargo ücretsiz
    public async Task Kargo_2000_TL_ve_ustunde_ucretsizdir(int adet, decimal beklenenKargo)
    {
        var urun = await UrunEkle(stok: 5, fiyat: 1000m);

        var siparis = await SiparisVer((urun, adet));

        Assert.Equal(beklenenKargo, siparis.KargoUcreti);
        Assert.Equal(adet * 1000m + beklenenKargo, siparis.Toplam);
    }

    [Fact]
    public async Task Siparis_numarasi_ES_ile_baslar_ve_on_karakterdir()
    {
        var urun = await UrunEkle(stok: 5);

        var siparis = await SiparisVer((urun, 1));

        Assert.Matches("^ES[A-Z2-9]{8}$", siparis.SiparisNo);
        Assert.Equal(SiparisDurumlari.OdemeBekliyor, siparis.Durum);
    }

    [Fact]
    public async Task Stoktan_fazla_adet_istenirse_kalan_miktar_soylenir()
    {
        var urun = await UrunEkle(stok: 2);

        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = Teslimat(),
            Kalemler = [new SepetKalemiIstegi { ParfumId = urun, Adet = 3 }],
        });

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
        Assert.Contains("kalan: 2", await yanit.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Stogu_biten_urun_siparis_edilemez()
    {
        var urun = await UrunEkle(stok: 0);

        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = Teslimat(),
            Kalemler = [new SepetKalemiIstegi { ParfumId = urun, Adet = 1 }],
        });

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
        Assert.Contains("tükendi", await yanit.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Olmayan_urun_siparis_edilemez()
    {
        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = Teslimat(),
            Kalemler = [new SepetKalemiIstegi { ParfumId = 999_999, Adet = 1 }],
        });

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
    }

    [Fact]
    public async Task Gecersiz_telefon_numarasi_reddedilir()
    {
        var urun = await UrunEkle(stok: 5);
        var teslimat = Teslimat();
        teslimat.Telefon = "abc";

        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = teslimat,
            Kalemler = [new SepetKalemiIstegi { ParfumId = urun, Adet = 1 }],
        });

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
        Assert.Contains("Telefon", await yanit.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Bos_sepetle_siparis_verilemez()
    {
        var yanit = await SiparisIstegi(new SiparisOlusturIstegi { Teslimat = Teslimat(), Kalemler = [] });

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
    }

    [Fact]
    public async Task Ozel_parfumun_fiyati_atolyedeki_fiyatla_aynidir()
    {
        int[] esanslar = [1, 16, 22];
        var degerlendirme = await Istemci.PostAsJsonAsync("/api/esanslar/degerlendir", new DegerlendirmeIstegi
        {
            EsansIdleri = [.. esanslar],
            Konsantrasyon = "Eau de Parfum",
            HacimMl = 50,
        });
        degerlendirme.EnsureSuccessStatusCode();
        var atolyeFiyati = (await degerlendirme.Content.ReadFromJsonAsync<DegerlendirmeSonucu>())!.Fiyat;

        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = Teslimat(),
            Kalemler =
            [
                new SepetKalemiIstegi
                {
                    Ozel = new OzelParfumIstegi
                    {
                        Ad = "Benim Kokum",
                        EsansIdleri = [.. esanslar],
                        Konsantrasyon = "Eau de Parfum",
                        HacimMl = 50,
                    },
                    Adet = 1,
                },
            ],
        });

        Assert.Equal(HttpStatusCode.Created, yanit.StatusCode);
        var siparis = await yanit.Content.ReadFromJsonAsync<SiparisDto>();
        Assert.Equal(atolyeFiyati, siparis!.Kalemler[0].BirimFiyat);
        Assert.Null(siparis.Kalemler[0].ParfumId);
    }

    [Fact]
    public async Task Tek_esansli_ozel_parfum_reddedilir()
    {
        var yanit = await SiparisIstegi(new SiparisOlusturIstegi
        {
            Teslimat = Teslimat(),
            Kalemler =
            [
                new SepetKalemiIstegi
                {
                    Ozel = new OzelParfumIstegi { Ad = "Tek Notalı", EsansIdleri = [1] },
                    Adet = 1,
                },
            ],
        });

        Assert.Equal(HttpStatusCode.BadRequest, yanit.StatusCode);
        Assert.Contains("en az 2 esans", await yanit.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Siparis_numara_ve_eposta_ile_sorgulanir_eposta_buyuk_harf_duyarsizdir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));

        var buyukHarfle = await Istemci.GetAsync(
            $"/api/siparisler/{siparis.SiparisNo}?eposta={Uri.EscapeDataString(siparis.Eposta.ToUpperInvariant())}");
        var yanlisEpostayla = await Istemci.GetAsync(
            $"/api/siparisler/{siparis.SiparisNo}?eposta=baskasi@ornek.com");

        Assert.Equal(HttpStatusCode.OK, buyukHarfle.StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, yanlisEpostayla.StatusCode);
    }

    [Fact]
    public async Task Siparis_olusturmak_stogu_dusurmez_stok_odemede_duser()
    {
        var urun = await UrunEkle(stok: 3);

        await SiparisVer((urun, 2));

        Assert.Equal(3, await Stok(urun));
    }
}
