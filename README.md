# CarBook

Bu proje, CQRS, MediatR, JWT tabanlı kimlik doğrulama ve ASP.NET MVC kullanılarak geliştirilmiş bir Araba Kiralama (Rent a Car) uygulamasıdır.
Backend tarafında Web API ve Entity Framework Core kullanılırken, Frontend tarafında ise ASP.NET MVC ile component tabanlı bir yapı tercih edilmiştir.
Özellikler
CQRS (Command Query Responsibility Segregation)
Okuma (Query) ve yazma (Command) işlemlerinin katman bazında ayrılması
MediatR
Komut ve sorguların handlerlar aracılığıyla yönetilmesi
JWT (JSON Web Token) tabanlı kimlik doğrulama
Rol bazlı yetkilendirme (Admin / Member)
Admin: CRUD işlemleri ve yönetim ekranları
Member: Listeleme, araç kiralama
ASP.NET MVC UI
ViewComponent yapısı ile modüler tasarım
IHttpClientFactory ile API iletişimi
Entity Framework Core ile Code First mimarisi
Repository Design Pattern
Swagger ile API dokümantasyonu
Fluent validasyon ile validayson kontrolü

Kullanılan Teknolojiler
ASP.NET Core 8.0
ASP.NET MVC
Entity Framework Core
MediatR
JWT (JSON Web Token)
FluentValidation
Swagger
SignalR

Proje, katmanlı mimari prensipleri doğrultusunda 5 ana katmandan oluşur:

🔹 CarBook.Domain
Uygulamanın temel veri yapıları bu katmanda yer alır.
Entity sınıfları (örneğin Car, Brand, Blog, Location vb.) burada tanımlanır.
Veri taşıma değil, sadece iş nesneleri tutulur.

🔹 CarBook.Application
Uygulamanın iş akışları, iş kuralları ve CQRS yapısı bu katmanda bulunur.
Command, Query, Handler, Result, Dto gibi sınıflar içerir.
MediatR ile birlikte çalışır ve WebApi'den gelen isteklerin yöneticisidir.

🔹 CarBook.Persistence
Veritabanı işlemleri ve Repository pattern bu katmanda uygulanır.
EF Core DbContext (CarBookContext) burada tanımlıdır.
Veri erişimi Application katmanındaki interface’lere göre gerçekleştirilir.
IRepository, ICarRepository, ILocationRepository gibi arabirimlerin EF karşılıklarını içerir.

🔹 CarBook.WebApi
API katmanıdır.
Tüm dış istemcilerle (ör. MVC UI) iletişim bu katman üzerinden kurulur.
JWT tabanlı kimlik doğrulama ve rol bazlı yetkilendirme bu katmanda yapılır.
Controller sınıfları sadece MediatR üzerinden CQRS akışlarını tetikler.
Swagger ile API testleri yapılabilir.

🔹 CarBook.WebUI
ASP.NET MVC tabanlı kullanıcı arayüzü sunan katmandır.
ViewComponent yapısıyla parçalı ve dinamik sayfa bölümleri oluşturulmuştur.
API ile iletişim IHttpClientFactory aracılığı ile yapılır.
Kullanıcıdan alınan veriler, API’ye gönderilir ve sonuçlar görüntülenir.
Admin ve Member rollerine göre sayfa erişimi kontrol edilir.

Kullanıcı Rolleri
Admin:
Araç ekleme, güncelleme, silme
Lokasyon yönetimi
Blog / Banner / Marka işlemleri

Member:
Araç listesini görme
Araç kiralama işlemleri
Blog içeriklerini okuma

<img width="1918" height="940" alt="carbook4" src="https://github.com/user-attachments/assets/a14a579d-d256-41ad-9ba4-136b01dd0411" />

<img width="1920" height="927" alt="carbook1" src="https://github.com/user-attachments/assets/c4c7321c-d4bd-4b19-b163-cf4d4a962e0a" />

<img width="1920" height="975" alt="carbook3" src="https://github.com/user-attachments/assets/10df9ccb-351c-42f5-b5c7-ce98d43a635f" />
<img width="1920" height="973" alt="carbook2" src="https://github.com/user-attachments/assets/65144c0d-72a7-4248-9fad-ec884fb9886a" />




Kurulum Notları
API ile MVC arasındaki tüm iletişim IHttpClientFactory aracılığı ile sağlanmaktadır.
JWT token login işleminden sonra cookie claim olarak tutulur.
API [Authorize(Roles = "Admin")] veya [Authorize(Roles = "Member")] attribute’ları ile korunur.
Yetkisiz erişimlerde AccessDenied sayfasına yönlendirme yapılır.

Öğrenilen Konular
Bu projede aşağıdaki konularda deneyim kazanılmıştır:
CQRS ve MediatR pattern’inin gerçek hayatta uygulanması
JWT tabanlı kimlik doğrulama ve rol bazlı yetkilendirme
ASP.NET MVC ile component bazlı modüler frontend
Web API ve MVC iletişimi için IHttpClientFactory kullanımı
Katmanlı mimari ve temiz kod prensipleri
SignalR ile gerçek zamanlı veri getirme
