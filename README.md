## mltool cli komutları
> $ new [model/dataset] [name]

İsmi [name] olarak verilen modeli/veri setini yaratır. Dosya programın çalıştığı klasörde oluşturulur.

> $ load [model/dataset] [file]

[path] model/veri seti dosyasını okur, doğrular ve train/eval için kullanılmak üzere belleğe kaydeder.

> $ mltool help

Yardım mesajını gösterir.

> $ mltool [komut] help
  
Komuta ait yardım mesajını gösterir.
  
> $ eval

Kullanıcıdan alınan sayının belleğe yüklenen model dosyasında ifade edilen fonksiyon altında görüntüsünü hesaplar.

> $ train

'load' komutu ile belleğe yüklenen dataset dosyasını kullanarak modeli eğitir
