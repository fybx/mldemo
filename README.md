## mldemo repository yapısı

> ../pyscripts

mltoolcli ve mltoolgui tarafından kullanılacak python scriptleri burada bulunacak.

> ../mltoolcli

.NET 6 SDK'sını hedef alan mltoolcli projesi bu klasörde yer alacak.

> ../mltoolgui

.NET 6 SDK'sını hedef alan (WinForms kullanıldığı için Windows'a kısıtlı) mltoolgui projesi bu klasörde yer alacak.

> ../artifacts

Derleme scriptlerinin hedefi bu klasör olacak. Derleme sonucu elde edilen çalıştırılabilirler ve python scriptleri burada yer alacak.

## mltoolcli komutları

mltoolcli'e dahil olan komutların ne işe yaradığı ve nasıl kullanıldığı hakkında bilgi almak için 'mltoolcli [komut] help' komutunu çalıştırınız. 

> $ mltool help

Yardım mesajını gösterir.

> $ mltool [komut] help
  
Komuta ait yardım mesajını gösterir.

> $ train [datasetPath] [modelPath]

Verilen veri seti dosyasını kullanarak verilen model dosyasındaki modeli eğitir.

> $ new [model/dataset] [name]

İsmi [name] olarak verilen modeli/veri setini yaratır. Dosya programın çalıştığı klasörde oluşturulur.
  
> $ eval [modelPath] [number]

Kullanıcıdan alınan sayının verilen model dosyasında ifade edilen fonksiyon altında görüntüsünü hesaplar.