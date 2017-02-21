#!/bin/bash

#build core
cd ../NotNet.Core
xbuild /p:Configuration=Release /t:Clean
xbuild /p:Configuration=Release NotNet.Core/NotNet.Core.csproj

#build forms
cd ../NotNet.Core.Forms
xbuild /p:Configuration=Release /t:Clean
xbuild /p:Configuration=Release NotNet.Core.Forms/NotNet.Core.Forms.csproj

#nuget pack
cd ../NuGet
pwd
./nugetpack.sh