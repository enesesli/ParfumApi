namespace ParfumApi.Dtos;

public record SayfaliSonuc<T>(
    List<T> Veriler,
    int ToplamKayit,
    int Sayfa,
    int Boyut,
    int ToplamSayfa);