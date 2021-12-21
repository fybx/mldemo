import sys
import matplotlib.pyplot as plot
from scipy.optimize import curve_fit
from numpy import arange


def polynomial5th(x, a, b, c, d, e, f):
    return a * (x ** 5) + b * (x ** 4) + c * (x ** 3) + d * (x ** 2) + (e * x) + f


def polynomial4th(x, a, b, c, d, e):
    return a * (x ** 4) + b * (x ** 3) + c * (x ** 2) + d * x + e


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
        dataset_path = sys.argv[1]  # kullanılacak veri seti dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] trainmodel.py dataset_path argümanı bekliyor")
        sys.exit()

    try:
        model_path = sys.argv[2]  # kullanılacak model dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] trainmodel.py model_path argümanı bekliyor")
        sys.exit()

    dataset_name, x, y = read_dataset(dataset_path)
    model_name, a, b, c, d, e, f = read_model(model_path)
    
    plot.xlabel("x ekseni")
    plot.ylabel("y ekseni")
    plot.title(model_name)
    
    popt, _ = curve_fit(polynomial5th, x, y)
    a, b, c, d, e, f = popt
    
    x_line = arange(min(x), max(x), 1)
    y_line = polynomial5th(x_line, a, b, c, d, e, f)
    save_model(model_path, model_name, a, b, c, d, e, f)

    plot.xlim(0, max(x))
    plot.ylim(0, max(y))
    plot.scatter(x, y)
    plot.plot(x_line, y_line, color='red')
    
    figure_path = model_name + " on " + dataset_name + ".png"
    plot.savefig(figure_path)
    print(f"mltool (pyscripts): [BİLGİ] model eğitildi. grafik '{figure_path}' konumuna kaydedildi")


main()
