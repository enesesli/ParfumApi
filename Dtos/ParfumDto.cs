namespace ParfumApi.Dtos;

public record ParfumDto(
    int Id,
    string Ad,
    string Aciklama,
    decimal Fiyat,
    int HacimMl,
    string Cinsiyet,
    int Stok,
    int MarkaId,
    string Marka);