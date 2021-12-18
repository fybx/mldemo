## mldemo nedir?
Cross-platform .NET ve Python pratiği amaçlı makine öğrenmesi konulu programlama ödevi

## İçerik Tablosu
1. [Derleme ve Test Etme](#derleme-ve-test-etme)
   1. [Gereksinimler](#gereksinimler)
      1. [Linux](#linux)
      2. [Windows](#windows)
      3. [Gereksinimlerin Kurulumu](#gereksinimlerin-kurulumu)
   2. [Test Etme](#test-etme)
2. [Repository yapısı](#mldemo-repository-yapısı)
3. [mltoolcli komutları](#mltoolcli-komutları)
4. [mltoolcli kullanımı](#mltoolcli-kullanımı)

## Derleme ve Test Etme

mltoolcli projesini GNU/Linux için ```build_cli.sh```, Windows için ```build_cli.bat``` scriptini kullanarak derleyebilirsiniz. 

mltoolgui projesi yalnızca Windows'ta çalışır, bu nedenle derlemek için yalnızca ```build_gui.bat``` scriptini kullanmalısınız.

### Gereksinimler

Python scriptlerinin çalışması için python3 kurulumunun düzgünce yapılmış ve gereksinimlerin pip ile kurulmuş olması gerekmektedir. 

#### Linux
Linux kullanıyorsanız python3 ön yüklü olarak gelecektir. Yalnızca pip kullanarak aşağıda verilen gereksinimleri kurmanız gerekecek. Bunu otomatik olarak yapmak için ```install_dep.sh``` scriptini çalıştırabilirsiniz.

#### Windows
Windows kullanıyorsanız Python'ın Microsoft Store'dan kurulduğu durumda ekstra bir şey yapmanıza gerek yoktur. Kurulumu python.org'daki full installer ile yaptıysanız, PATH'teki Python klasöründe bulunan python.exe çalıştırılabilir dosyasına sembolik link oluşturmanız gerekecek.

Sembolik linki oluşturmak için yükseltilmiş komut istemini başlatın. Ardından aşağıdaki komutu çalıştırın:

> mklink "C:\python\kurulu\klasör\python3.exe" "C:\python\kurulu\klasör\python.exe"

#### Gereksinimlerin kurulumu
> $ pip install [numpy](https://numpy.org/ "NumPy")

> $ pip install [scipy](https://scipy.org/ "SciPy") 

> $ pip install [matplotlib](https://matplotlib.org/ "Matplotlib")

### Test Etme

Platforma uygun derleme scriptini kullanarak elde edilecek çıktılar, yerel repository'nizin ```/artifact``` klasöründe bulunacak. 

```artifacts``` klasöründe;
- ```build_cli.sh``` kullandıysanız ```mltoolcli```,
- ```build_cli.bat``` kullandıysanız ```mltoolcli.exe```,
- ```build_gui.bat``` kullandıysanız ```mltoolgui.exe``` ve ```mltoolcli.exe``` bulunacak.

mltoolgui temelde mltoolcli'ın bütün özelliklerini *saran* bir grafik kullanıcı arayüzü olduğundan dolayı kendisine özel bir rehbere sahip değil. Barındırdığı bütün özellikler hali hazırda mltoolcli'da bulunan özelliklerden oluşuyor.

[mltoolcli'ın içerdiği komutlar](#mltoolcli-komutları) ve [nasıl kullanılacağına dair detaylara](#mltoolcli-kullanımı) ulaşmak için ilgili linklere tıklayabilirsiniz.

## mldemo repository yapısı

- ../pyscripts

mltoolcli ve mltoolgui tarafından kullanılacak python scriptleri burada bulunuyor.

- ../mltoolcli

.NET 6 SDK'sını hedef alan mltoolcli projesi bu klasörde yer alıyor.

- ../mltoolgui

.NET 6 SDK'sını hedef alan (WinForms kullanıldığı için yalnızca Windows'ta çalışabilir) mltoolgui projesi bu klasörde yer alıyor.

- ../artifacts

Derleme scriptlerinin çıktı hedefi bu klasördür. Derleme sonucu elde edilen çalıştırılabilirler ve python scriptleri burada yer alacak.

## mltoolcli komutları

mltoolcli'e dahil olan komutların ne işe yaradığı ve nasıl kullanıldığı hakkında bilgi almak için ```mltoolcli [komut] help``` komutunu çalıştırabilirsiniz. 

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

## mltoolcli kullanımı

mltoolcli, çeşitli veri setlerini kullanarak matematiksel fonksiyonların eğitilmesini ve böylece istatistiksel verilerin çözümlenmesini kolaylaştıran bir yardımcı yazılımdır. 

eğitilen matematiksel fonksiyonlara **model**, eğitimde kullanılan ve temel olarak sıralı ikili biçimde ifade edilebilen verileri bulunduran setlere de **veri seti** denir.

model dosyaları şu anda yalnızca 5. dereceden polinominal fonksiyonları ifade edebilmektedir. aynı şekilde veri setleri de sadece 64 adet sıralı ikili tutabilir. bu sınırlamalar prototipleme aşaması henüz bittiğinden ötürü bulunmaktadır ve ilerleyen sürümlerde değiştirilmesi amaçlanmaktadır.

yukarıda yer alan [komut listesi](#mltoolcli-komutları) yardımıyla uygulamayı kullanmaya başlayabilirsiniz.
