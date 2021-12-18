## mldemo
.NET ve Python kullanan cross-platform makine öğrenmesi modeli

1. [Derleme ve Test Etme](#derleme-ve-test-etme)
2. [Repository yapısı](#mldemo-repository-yapısı)

## Derleme ve Test Etme

mltoolcli projesini GNU/Linux için build_client.sh, Windows için build_client.bat scriptini kullanarak derleyebilirsiniz. 

mltoolgui projesi yalnızca Windows'ta çalışır, bu nedenle derlemek için yalnızca build_gui.bat scriptini kullanmalısınız.

### Gereksinimler

Python scriptlerinin çalışması için python3 kurulumunun düzgünce yapılmış olması gerekmektedir. 

#### Linux
Linux kullanıyorsanız python3 hali hazırda kurulu gelecektir. Yalnızca pip kullanarak aşağıda verilen gereksinimleri kurmanız gerekecek. Bunu otomatik olarak yapmak için install_dep.sh scriptini çalıştırabilirsiniz.

#### Windows
Windows kullanıyorsanız Python'ın Microsoft Store'dan kurulduğu durumda ekstra bir şey yapmanıza gerek yoktur. Kurulumu python.org'daki full installer ile yaptıysanız, PATH'teki Python klasöründe bulunan python.exe çalıştırılabilir dosyasına sembolik link oluşturmanız gerekecek.

Sembolik linki oluşturmak için yükseltilmiş bir komut istemi başlatın. Ardından aşağıdaki komutu çalıştırın

> mklink "C:\python\kurulu\klasör\python3.exe" "C:\python\kurulu\klasör\python.exe"

#### Gereksinimlerin kurulumu
> $ pip install [numpy](https://numpy.org/ "NumPy")

> $ pip install [scipy](https://scipy.org/ "SciPy") 

> $ pip install [matplotlib](https://matplotlib.org/ "Matplotlib")

## mldemo repository yapısı

> ../pyscripts

mltoolcli ve mltoolgui tarafından kullanılacak python scriptleri burada bulunuyor.

> ../mltoolcli

.NET 6 SDK'sını hedef alan mltoolcli projesi bu klasörde yer alıyor.

> ../mltoolgui

.NET 6 SDK'sını hedef alan (WinForms kullanıldığı için yalnızca Windows'ta çalışabilir) mltoolgui projesi bu klasörde yer alıyor.

> ../artifacts

Derleme scriptlerinin çıktı hedefi bu klasördür. Derleme sonucu elde edilen çalıştırılabilirler ve python scriptleri burada yer alacak.

## mltoolcli komutları

mltoolcli'e dahil olan komutların ne işe yaradığı ve nasıl kullanıldığı hakkında bilgi almak için 'mltoolcli [komut] help' komutunu çalıştırabilirsiniz. 

> $ mltool help

Genel yardım mesajını gösterir.

> $ mltool [komut] help
  
[komut] komutuna ait yardım mesajını gösterir.

> $ train [datasetPath] [modelPath]

[datasetPath] konumunda bulunan veri seti dosyasını kullanarak [modelPath] konumunda bulunan model dosyasındaki modeli eğitir ve sonuçları aynı dosyaya kaydeder.

> $ new [model/dataset] [name]

İsmi [name] olarak verilen modeli/veri setini yaratır. Dosya programın çalıştığı klasörde oluşturulur.

> $ new [bundle] [name]

İsmi [name] olarak verilen model ve veri seti dosyalarını yaratır. Tek seferde aynı isimli dosyaları oluşturmak için kullanabilirsiniz. Dosyalar programın çalıştığı klasörde oluşturulur.
  
> $ eval [modelPath] [number]

Kullanıcıdan alınan sayının verilen model dosyasında ifade edilen fonksiyon altında görüntüsünü hesaplar.
