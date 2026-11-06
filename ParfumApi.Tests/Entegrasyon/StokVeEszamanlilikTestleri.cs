namespace ParfumApi.Tests.Entegrasyon;

// Son ürün için yarışan müşteriler: stok asla eksiye düşmemeli
public class StokVeEszamanlilikTestleri(ApiFabrikasi fabrika) : ApiTestTabani(fabrika)
{
    [Fact]
    public async Task Stok_1_iken_iki_siparis_gelirse_sadece_ilk_odeyen_alir()
    {
        var urun = await UrunEkle(stok: 1);
        var birinci = await SiparisVer((urun, 1));
        var ikinci = await SiparisVer((urun, 1));   // stok henüz düşmediği için ikisi de oluşturulabilir

        var birinciOdeme = await KartlaOde(birinci);
        var ikinciOdeme = await KartlaOde(ikinci);

        Assert.Equal(HttpStatusCode.OK, birinciOdeme.StatusCode);
        Assert.Equal(HttpStatusCode.Conflict, ikinciOdeme.StatusCode);
        Assert.Equal(0, await Stok(urun));
        Assert.Equal(SiparisDurumlari.OdemeBekliyor, (await SiparisiGetir(ikinci))!.Durum);
    }

    [Fact]
    public async Task Ayni_anda_gelen_odemelerde_stok_eksiye_dusmez()
    {
        const int stok = 2, musteriSayisi = 6;
        var urun = await UrunEkle(stok);
        var siparisler = new List<SiparisDto>();
        for (var i = 0; i < musteriSayisi; i++)
            siparisler.Add(await SiparisVer((urun, 1)));

        // Hepsi aynı anda "Öde"ye basıyor
        var yanitlar = await Task.WhenAll(siparisler.Select(s => KartlaOde(s)));

        Assert.Equal(stok, yanitlar.Count(y => y.StatusCode == HttpStatusCode.OK));
        Assert.Equal(musteriSayisi - stok, yanitlar.Count(y => y.StatusCode == HttpStatusCode.Conflict));
        Assert.Equal(0, await Stok(urun));
    }

    [Fact]
    public async Task Bir_kalemin_stogu_yetmezse_diger_kalemlerin_stogu_da_dusmez()
    {
        var bol = await UrunEkle(stok: 10);
        var az = await UrunEkle(stok: 1);
        var siparis = await SiparisVer((bol, 2), (az, 1));

        // Başka biri son ürünü kapıyor
        await KartlaOde(await SiparisVer((az, 1)));

        var yanit = await KartlaOde(siparis);

        Assert.Equal(HttpStatusCode.Conflict, yanit.StatusCode);
        Assert.Equal(10, await Stok(bol));   // işlem (transaction) tümüyle geri alındı
        Assert.Equal(0, await Stok(az));
    }
}
