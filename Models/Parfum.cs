namespace ParfumApi.Models;

public class Parfum
{
    public int Id { get; set; }
    public string Ad { get; set; } = "";
    public string Aciklama { get; set; } = "";

    public decimal Fiyat { get; set; }

    // İndirimdeyse ürünün eski fiyatı; indirim yoksa null
    public decimal? EskiFiyat { get; set; }

    public int HacimMl { get; set; }
    public string Cinsiyet { get; set; } = "";       // "Kadın", "Erkek", "Unisex"
    public int Stok { get; set; }

    // "Çiçeksi", "Odunsu", "Oryantal", "Ferah", "Gurme", "Aromatik"
    public string KokuAilesi { get; set; } = "";

    // "Eau de Toilette", "Eau de Parfum", "Extrait de Parfum"
    public string Konsantrasyon { get; set; } = "";

    // Nota piramidi: virgülle ayrılmış notalar
    public string UstNotalar { get; set; } = "";
    public string KalpNotalar { get; set; } = "";
    public string AltNotalar { get; set; } = "";

    // Ön yüzde çizilen şişe görseli için: sıvının rengi ve şişe biçimi (0-4)
    public string Renk { get; set; } = "#c9a77c";
    public int SiseTipi { get; set; }

    public bool Yeni { get; set; }

    // Yönetim panelinden yüklenen fotoğrafın adresi (ör. "/gorseller/parfum-5-....jpg").
    // Boşsa sitede çizilmiş şişe gösterilir.
    public string? GorselYolu { get; set; }

    public int MarkaId { get; set; }
    public Marka? Marka { get; set; }
}
