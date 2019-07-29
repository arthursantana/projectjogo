.PHONY: default all clean run
default: winforms.exe
all: winforms.exe console.exe
winforms.exe: src/
	mcs -r:./lib/MonoGame.Framework.dll -target:winexe -out:dist/winforms.exe src/*.cs src/*/*.cs
console.exe: src/
	mcs -r:./lib/MonoGame.Framework.dll -target:exe -out:dist/console.exe src/*.cs src/*/*.cs
run: winforms.exe
	cd dist; mono winforms.exe; cd ..
clean:
	rm -f dist/*.exe
