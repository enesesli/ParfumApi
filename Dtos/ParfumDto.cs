namespace ParfumApi.Dtos;

public record ParfumDto(
    int Id,
    string Ad,
    string Aciklama,
    decimal Fiyat,
    decimal? EskiFiyat,
    int HacimMl,
    string Cinsiyet,
    int Stok,
    string KokuAilesi,
    string Konsantrasyon,
    string UstNotalar,
    string KalpNotalar,
    string AltNotalar,
    string Renk,
    int SiseTipi,
    bool Yeni,
    int MarkaId,
    string Marka,
    string? GorselYolu);
