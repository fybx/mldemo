import sys
import matplotlib.pyplot as plot
from scipy.optimize import curve_fit
from numpy import arange


def polyfunc(x, a, b, c, d, e, f):
    # y = ax^5 + bx^4 + cx^3 + dx^2 + ex + f
    return (a * (x ** 5)) + (b * (x ** 4)) + (c * (x ** 3)) + (d * x * x) + (e * x) + f


def read_dataset(location):
    with open(location) as f:
        lines = f.read().splitlines()

    del lines[0]
    name = lines[0]
    del lines[0]
    lines = [int(i) for i in lines]  # list[str] => list[int]
    xvals = lines[0:32]
    yvals = lines[32:64]
    return name, xvals, yvals


def read_model(location):
    with open(location) as f:
        lines = f.read().splitlines()

    return lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7]


def save_model(location, name, a, b, c, d, e, f):
    with open(location, 'w') as file:
        file.write("mltool modeli\n")
        file.write(name + '\n')
        file.write(str(a) + '\n')
        file.write(str(b) + '\n')
        file.write(str(c) + '\n')
        file.write(str(d) + '\n')
        file.write(str(e) + '\n')
        file.write(str(f) + '\n')


def main():
    print("mltool (pyscripts): model eğitiliyor!")
    try:
        datasetloc = sys.argv[1]  # kullanılacak veri seti dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] trainmodel.py datasetloc argümanı bekliyor")
        sys.exit()

    try:
        modelloc = sys.argv[2]  # kullanılacak model dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] trainmodel.py modelloc argümanı bekliyor")
        sys.exit()

    datasetname, x, y = read_dataset(datasetloc)
    modelname, a, b, c, d, e, f = read_model(modelloc)
    plot.xlabel("x ekseni")
    plot.ylabel("y ekseni")
    plot.title(modelname)
    popt, _ = curve_fit(polyfunc, x, y)
    a, b, c, d, e, f = popt
    plot.scatter(x, y)
    x_line = arange(min(x), max(x), 1)
    y_line = polyfunc(x_line, a, b, c, d, e, f)
    save_model(modelloc, modelname, a, b, c, d, e, f)
    plot.plot(x_line, y_line, '--', color='red')
    figloc = modelname + " on " + datasetname + ".png"
    plot.savefig(figloc)
    print("mltool (pyscripts): [BİLGİ] model eğitildi. grafik '%s' konumuna kaydedildi" % figloc)


main()
