namespace ParfumApi.Tests.Entegrasyon;

public class SiparisYonetimiTestleri(ApiFabrikasi fabrika) : ApiTestTabani(fabrika)
{
    private async Task<SiparisDto> OdenmisSiparis(int urun, int adet = 1)
    {
        var siparis = await SiparisVer((urun, adet));
        (await KartlaOde(siparis)).EnsureSuccessStatusCode();
        return siparis;
    }

    [Fact]
    public async Task Siparis_listesi_giris_yapmadan_gorulemez()
    {
        var yanit = await Istemci.GetAsync("/api/siparisler");

        Assert.Equal(HttpStatusCode.Unauthorized, yanit.StatusCode);
    }

    [Fact]
    public async Task Yanlis_sifreyle_giris_yapilamaz()
    {
        var yanit = await Istemci.PostAsJsonAsync("/api/auth/giris", new GirisDto
        {
            KullaniciAdi = ApiFabrikasi.AdminKullaniciAdi,
            Sifre = "yanlis-sifre",
        });

        Assert.Equal(HttpStatusCode.Unauthorized, yanit.StatusCode);
    }

    [Fact]
    public async Task Siparis_sadece_izin_verilen_sirayla_ilerler()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await OdenmisSiparis(urun);

        // Ödendi -> Kargoda atlanamaz, önce hazırlanmalı
        Assert.Equal(HttpStatusCode.BadRequest, (await DurumDegistir(siparis.Id, SiparisDurumlari.Kargoda)).StatusCode);

        Assert.Equal(HttpStatusCode.OK, (await DurumDegistir(siparis.Id, SiparisDurumlari.Hazirlaniyor)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await DurumDegistir(siparis.Id, SiparisDurumlari.Kargoda)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await DurumDegistir(siparis.Id, SiparisDurumlari.TeslimEdildi)).StatusCode);

        // Teslim edilmiş sipariş iptal edilemez
        Assert.Equal(HttpStatusCode.BadRequest, (await DurumDegistir(siparis.Id, SiparisDurumlari.IptalEdildi)).StatusCode);
        Assert.Equal(SiparisDurumlari.TeslimEdildi, (await SiparisiGetir(siparis))!.Durum);
    }

    [Fact]
    public async Task Odenmis_siparis_iptal_edilince_stok_geri_eklenir()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await OdenmisSiparis(urun, adet: 2);
        Assert.Equal(3, await Stok(urun));

        var yanit = await DurumDegistir(siparis.Id, SiparisDurumlari.IptalEdildi);

        Assert.Equal(HttpStatusCode.OK, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));
    }

    [Fact]
    public async Task Odenmemis_siparis_iptal_edilince_stok_degismez()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 2));

        var yanit = await DurumDegistir(siparis.Id, SiparisDurumlari.IptalEdildi);

        Assert.Equal(HttpStatusCode.OK, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));   // zaten hiç düşmemişti; fazladan eklenmemeli
    }

    [Fact]
    public async Task Iptal_edilmis_siparis_odenemez()
    {
        var urun = await UrunEkle(stok: 5);
        var siparis = await SiparisVer((urun, 1));
        await DurumDegistir(siparis.Id, SiparisDurumlari.IptalEdildi);

        var yanit = await KartlaOde(siparis);

        Assert.Equal(HttpStatusCode.Conflict, yanit.StatusCode);
        Assert.Equal(5, await Stok(urun));
    }

    [Fact]
    public async Task Liste_duruma_gore_filtrelenir()
    {
        var urun = await UrunEkle(stok: 5);
        var odenmis = await OdenmisSiparis(urun);
        var bekleyen = await SiparisVer((urun, 1));

        var istek = await AdminIstegi(HttpMethod.Get,
            $"/api/siparisler?boyut=50&durum={Uri.EscapeDataString(SiparisDurumlari.Odendi)}");
        var sonuc = await (await Istemci.SendAsync(istek)).Content.ReadFromJsonAsync<SayfaliSonuc<SiparisDto>>();

        Assert.All(sonuc!.Veriler, s => Assert.Equal(SiparisDurumlari.Odendi, s.Durum));
        Assert.Contains(sonuc.Veriler, s => s.Id == odenmis.Id);
        Assert.DoesNotContain(sonuc.Veriler, s => s.Id == bekleyen.Id);
    }
}
