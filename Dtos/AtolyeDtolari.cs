using System.ComponentModel.DataAnnotations;

namespace ParfumApi.Dtos;

public record EsansDto(
    int Id,
    string Ad,
    string Katman,
    string Aile,
    string Aciklama,
    string Renk,
    decimal EkFiyat);

public class DegerlendirmeIstegi
{
    [MaxLength(9, ErrorMessage = "En fazla 9 esans seçebilirsin.")]
    public List<int> EsansIdleri { get; set; } = new();

    [RegularExpression("^(Eau de Toilette|Eau de Parfum|Extrait de Parfum)$",
        ErrorMessage = "Konsantrasyon Eau de Toilette, Eau de Parfum veya Extrait de Parfum olmalı.")]
    public string Konsantrasyon { get; set; } = "Eau de Parfum";

    [AllowedValues(30, 50, 100, ErrorMessage = "Hacim 30, 50 veya 100 ml olmalı.")]
    public int HacimMl { get; set; } = 50;
}

public record CiftUyumu(string EsansA, string EsansB, int Puan, string Aciklama);

public record DegerlendirmeSonucu(
    int Puan,                               // 0-100
    string Seviye,                          // "Mükemmel uyum", "Uyumlu", ...
    string Ozet,                            // "Narenciyeli bir açılış, çiçeksi bir kalp ve odunsu bir iz."
    List<CiftUyumu> Ciftler,
    List<string> Uyarilar,
    Dictionary<int, double> AdayPuanlari,   // seçilmemiş her esansın mevcut seçimle ortalama uyumu (-2..2)
    decimal Fiyat);
