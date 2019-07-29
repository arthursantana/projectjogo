.PHONY: default all clean run dist content
default: winforms.exe
all: winforms.exe console.exe
content: content/Content.mgcb
	cd content; mgcb --platform=DesktopGL Content.mgcb; cd ..
dist: content
	rm -rf dist; mkdir dist; mkdir dist/Content; cp lib/* dist; cp content/bin/* dist/Content
winforms.exe: src/ dist
	mcs -r:./lib/MonoGame.Framework.dll -target:winexe -out:dist/winforms.exe src/*.cs src/*/*.cs
console.exe: src/ dist
	mcs -r:./lib/MonoGame.Framework.dll -target:exe -out:dist/console.exe src/*.cs src/*/*.cs
run: winforms.exe
	cd dist; mono winforms.exe; cd ..
clean:
	rm -rf dist
