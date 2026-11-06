global using System.Net;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using ParfumApi.Dtos;
global using ParfumApi.Models;
global using ParfumApi.Tests.TestAltyapisi;
global using Xunit;

// Entegrasyon testleri ortam değişkenleriyle ayar verdiği için test sınıfları sırayla çalışır
[assembly: CollectionBehavior(DisableTestParallelization = true)]
