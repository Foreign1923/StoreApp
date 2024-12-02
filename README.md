# StoreApp

StoreApp, kullanıcıların ürünleri görüntüleyebildiği, sepete ekleyebildiği ve alışveriş işlemlerini yönetebildiği bir e-ticaret web uygulamasıdır. 
Bu proje, CRUD işlemleri, kullanıcı kimlik doğrulama (login/logout), sayfalama (pagination) ve yönetici paneli gibi özellikleri modern web teknolojileriyle hayata geçirmektedir.

## Özellikler

### Kullanıcı Yönetimi
- **Kayıt Olma ve Giriş Yapma:** Kullanıcılar hesap oluşturabilir ve uygulamaya giriş yapabilir.  
- **Oturum Yönetimi:** Giriş yapan kullanıcılar, oturum süresi boyunca verilerine erişebilir ve çıkış yapabilir.  

### Ürün Yönetimi
- **CRUD İşlemleri:**  
  - Ürün ekleme, düzenleme, silme ve görüntüleme işlemleri.  
- **Ürün Listeleme ve Detay Görüntüleme:**  
  - Kullanıcılar, ürünlerin detaylarını ve açıklamalarını görebilir.  
- **Sayfalama (Pagination):** Çok sayıda ürünü düzenli bir şekilde göstermek için sayfalama desteği.

### Alışveriş İşlemleri
- **Sepete Ekleme:** Kullanıcılar, ürünleri sepete ekleyebilir ve birden fazla ürünle alışveriş yapabilir.  
- **Sepet Yönetimi:** Sepet içeriği görüntülenebilir, ürünler kaldırılabilir veya miktarları düzenlenebilir.  
- **Sipariş Tamamlama:** Sepet içeriği üzerinden alışveriş işlemi tamamlanabilir.  

### Yönetici Paneli
- **Yönetim Arayüzü:** Yalnızca yöneticilerin erişimine açık bir panel bulunmaktadır.  
- **Ürün Yönetimi:**  
  - Ürünleri ekleme, düzenleme ve silme işlemleri bu panel üzerinden yapılabilir.  
- **Kullanıcı Yönetimi:** Kullanıcı hesaplarını görüntüleme ve gerektiğinde düzenleme işlemleri.  
- **İstatistik ve Raporlama:** Satış ve kullanıcı etkinlikleri gibi veriler üzerinden temel raporlar görüntüleme.

### Ek Özellikler
- **Arama ve Filtreleme:** Kullanıcılar, ürünler arasında arama yapabilir veya filtreleme kriterlerini kullanabilir.  
- **Veritabanı Yönetimi:** MSSQL kullanılarak ürün ve kullanıcı verilerinin güvenli şekilde saklanması.  

## Teknolojiler
- **Frontend:** HTML, CSS, JavaScript  
- **Backend:** ASP.NET Core  
- **Database:** MSSQL  
- **Authentication:** ASP.NET Identity (Login/Logout)  

## Kurulum
1. Bu projeyi klonlayın:
   ```bash
   git clone https://github.com/Foreign1923/StoreApp.git
