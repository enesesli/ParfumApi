namespace ParfumApi.Models;

// Aile kuralının dışında kalan özel esans çiftleri (ör. Gül + Ud klasik bir uyumdur).
// Çift her zaman küçük id önce olacak şekilde saklanır; anahtar iki id'nin birleşimidir.
public class EsansUyumu
{
    public int EsansAId { get; set; }
    public int EsansBId { get; set; }

    // -2 çatışır, -1 riskli, 0 nötr, 1 uyumlu, 2 birbirini tamamlar
    public int Puan { get; set; }

    public string Aciklama { get; set; } = "";
}
