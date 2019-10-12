dotnet publish -r win10-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true -o bin\win-x64
dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true -o bin\linux-x64
dotnet publish -r linux-arm -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true -o bin\linux-arm
dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true -o bin\osx-x64

cp README.md bin\win-x64\readme.txt
cp README.md bin\linux-x64\readme.txt
cp README.md bin\win-x64\readme.txt
cp README.md bin\linux-arm\readme.txt

cd MkvChapterGenerator

rmdir /Q /S bin
rmdir /Q /S obj

cd ..
