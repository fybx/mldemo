import sys
import os


def main():
    print("mltool (pyscripts): [BİLGİ] yeni model yaratılıyor!")
    try:
        file_path = sys.argv[1]   # cli tarafından yaratılan model dosyasının tam konumu
    except IndexError:
        print("mltool (pyscripts): [HATA] newmodel.py file_path argümanı bekliyor.")
        sys.exit()

    with open(file_path, 'w') as f:
        f.write("mltool modeli\n")
        f.write(os.path.basename(file_path).split('.')[0] + '\n')
        for i in range(6):
            f.write("1\n")

    print("mltool (pyscripts): [BİLGİ] model yaratıldı.")
    print(f"Konum: {file_path}")


main()
