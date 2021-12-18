import random
import sys
import os


def main():
    print("mltool (pyscripts): [BİLGİ] yeni veri seti yaratılıyor!")
    try:
        file_path = sys.argv[1]  # cli tarafından yaratılan veri seti dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] newdataset.py file_path argümanı bekliyor.")
        sys.exit()

    x_values = []
    y_values = []

    x_value = 1
    while x_value < 1025:
        y_value = random.randint(1, 512)
        x_values.append(x_value)
        y_values.append(y_value)
        x_value += 32

    with open(file_path, 'w') as f:
        f.write("mltool veri seti\n")
        f.write(os.path.basename(file_path).split('.')[0] + '\n')
        for item in x_values:
            f.write("%s\n" % item)
        for item in y_values:
            f.write("%s\n" % item)

    print("mltool (pyscripts): [BİLGİ] veri seti yaratıldı.")
    print(f"Konum: {file_path}")


main()
