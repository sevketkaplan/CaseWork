# CaseWork v1.0
Proje 1000 Adet benzersiz kod üreten & doğrulayan
Ayrıca Json Parse olayı içeren bir projedir.
Aşağıda detaylar mevcuttur.
Sistem .net6 Web API ile geliştirilmiştir.
Gerekli SDK => .net6 SDK
Indirilen Nuget Package=> NewtonSoft.JSON

#Projenin Çalıştırılması
------------------------
Projeyi indirip açtıktan sonra Solution Explorer içerisindeki Solution'KCE'
Properties tıkladıktan sonra Common Properties-> Startup Project sekmesine gelelim.
Burada Single Startup project seçilince ardından "KCE" şeçeneğini de seçiyoruz. Tamam butonuna tıklayıp çıkıyoruz.
Daha sonra projemizin Start butonunun yanında KCE yazdığından emin oluyoruz ve startlıyoruz.

#Generate Code Methodu
----------------------
CryptoCode Class içindeki GenerateCode ve VerifyCode methodları

1000 Adet benzersiz Code üretimi methodu
URL=>https://localhost:7231/Case/GenerateCode

Kodları Doğrulama URL=>https://localhost:7231/Case/VerifyCode?code=Üretilen_Kodlardan_Birtanesi_YAZILACAK
Kodu doğrulamak isterseniz de (Dediğiniz gibi doğrulama Algoritmik olarak) bir GET string parametresi alacaktir. Parametre adı "code" 'dur.
Örnek Kullanımı:https://localhost:7231/Case/VerifyCode?code=A1B2C3D4


#Json Parse Methodu
--------------------
Proje içerisinde Extentions klasörü içindeki "response.json" dosyasında verilmiş olan json data DataObject ClassLibrary içerisindeki JsonResponse sınıfına dönüştürülmüştür.
JsonResponse sınıfı içerisindeki tanımlanan özelliklerde iç içe olan sınıflar da aynı ClassLibrary ' de tanımlanmıştır.

Methodun çalışması için gerekli API GET URL=> https://localhost:7231/Case/CaseTwo

Methodun Controller Class'ı=> Case  Action =>CaseTwo


            

