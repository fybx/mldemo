import random
import sys

print("mltool: yeni veri seti yaratılıyor!")
try:
    fileloc = sys.argv[1]   # cli tarafından yaratılan veri seti dosyasının tam konumu
except IndexError:
    print("mltool: newdataset.py fileloc argümanı bekliyor.")
    sys.exit()

xvals = []
yvals = []

xval = 1
while xval < 1025:
    yval = random.randint(1, 512)
    xvals.append(xval)
    yvals.append(yval)
    xval += 32

xlen = len(xvals)
ylen = len(yvals)

with open(fileloc, 'w') as f:
    f.write("mltool veri seti\n")
    f.write("%s," % xlen)
    f.write("%s\n" % ylen)
    for item in xvals:
        f.write("%s\n" % item)
    for item in yvals:
        f.write("%s\n" % item)
