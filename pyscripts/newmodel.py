import sys
import os


def main():
    print("mltool: yeni model yaratılıyor!")
    try:
        fileloc = sys.argv[1]   # cli tarafından yaratılan model dosyasının tam konumu
    except IndexError:
        print("mltool: newmodel.py fileloc argümanı bekliyor.")
        sys.exit()

    with open(fileloc, 'w') as f:
        f.write("mltool modeli\n")
        f.write(os.path.basename(fileloc).split('.')[0] + '\n')
        for i in range(6):
            f.write("1\n")


main()