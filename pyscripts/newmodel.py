import sys
import os


def main():
    print("mltool (pyscripts): [BİLGİ] yeni model yaratılıyor!")
    try:
        fileloc = sys.argv[1]   # cli tarafından yaratılan model dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] newmodel.py fileloc argümanı bekliyor.")
        sys.exit()

    with open(fileloc, 'w') as f:
        f.write("mltool modeli\n")
        f.write(os.path.basename(fileloc).split('.')[0] + '\n')
        for _ in range(6):
            f.write("1\n")

    print("mltool (pyscripts): [BİLGİ] model yaratıldı.")
    print("Konum: %s" % fileloc)


main()
