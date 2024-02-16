# MVC Online Ticari Otomasyon Projesi

Bu proje MVC5, MSSQL ve Code First yaklaşımı kullanılarak oluşturulmuştur. Proje yapımında AdminLTE ve çeşitli temalar kullanılmıştır.

## Kullanıcı Rolleri

Projede 2 temel kullanıcı yer almaktadır:
- Admin(Employee)
- Customer

### Admin İşlemleri

Adminlerin rolleri bulunmaktadır. Örneğin, B rolüne sahip bir admin Departman kaydı yapabilirken, A rolüne sahip admin bu sekmeyi görüntüleyememektedir. Adminlerin yaptığı işlemler şunlardır:
- Kategori CRUD işlemleri
- Müşteri CRUD işlemleri
- Employee CRUD işlemleri
- Departman CRUD işlemleri
- Fatura CRUD işlemleri
- Fatura çıktı oluşturma işlemi
- Kargo bilgisi tanımlama işlemi
- To Do List oluşturma işlemi
- Satış işlemi
- Mesaj gönderme işlemi
- Duyuru oluşturma işlemi
- Ürün detayları sayfasında ürünlerin tüm bilgilerinin görüntülenmesi

### Kullanıcı İşlemleri

Kullanıcıların yaptığı işlemler şu şekildedir:
- İsim, soyisim, şehir ve şifre güncelleme işlemi
- Admin tarafından oluşturulmuş duyuruları görüntüleme işlemi
- Adminlere ve diğer kullanıcılara mesaj gönderme işlemi
- Kargo takibi (Kullanıcının kargo kodunu bilmediği varsayılıp giriş yaptığında tüm kargolarının getirilmesi sağlanmıştır.)
- Verdiği siparişleri görüntüleme işlemi
- Session kullanımı ile giriş-çıkış işlemleri

## İstatistik ve Grafikler

Ayrıca projede çeşitli istatistik ve grafik sayfaları yer almaktadır. Bu sayfalardaki bilgiler dinamik olarak güncellenmektedir.

## Kargo Takip

Kargo tanımlama işlemi sırasında kargo takip kodunun benzersiz olması sağlanmıştır.

## Hata Yönetimi

Projede hata sayfası tanımlanması yapılmıştır. Hata alınması durumunda hata kodunun ekrana yazdırılması sağlanmaktadır.

## Kurulum

Projeyi kendi bilgisayarınızda çalıştırmak için şu adımları izleyin:

1. Proje içerisinde bulunan "1-Database" klasöründe yer alan veritabanı dosyasını kendi bilgisayarınıza yükleyin.
2. Proje dosyalarını Visual Studio'da açın.
3. `Web.config` dosyasını açın.
4. Aşağıdaki satırları bulun:

```xml
<connectionStrings>
  <add name="Context" connectionString="Data Source=.; Initial Catalog=DbTicari ; Integrated Security=TRUE;" providerName="System.Data.SqlClient" />
</connectionStrings>
```
Burada bulunan `SERVER_NAME` kısmını kendi bilgisayarınızın SQL adresi ile değiştirin. (SQL Server Management Studio'da bulunan "Connect" ekranında "Server name" kısmı)
Database kısmında `DbTicari` yazmasına dikkat edin. (Attığım veritabanı dosyasının ismidir.)
