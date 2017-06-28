#!/bin/bash

#build core
cd ../NotNet.Core
msbuild /p:Configuration=Release /t:Clean
msbuild /p:Configuration=Release NotNet.Core/NotNet.Core.csproj

#build forms
cd ../NotNet.Core.Forms
msbuild /p:Configuration=Release /t:Clean
msbuild /p:Configuration=Release NotNet.Core.Forms/NotNet.Core.Forms.csproj

#nuget pack
cd ../NuGet
pwd
./nugetpack.sh
