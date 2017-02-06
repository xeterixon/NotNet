#!/bin/bash
cd ../NotNet.Core
xbuild /p:Configuration=Release /t:Clean
xbuild /p:Configuration=Release NotNet.Core/NotNet.Core.csproj

cd ../NotNet.Core.Forms
xbuild /p:Configuration=Release /t:Clean
xbuild /p:Configuration=Release NotNet.Core.Forms/NotNet.Core.Forms.csproj
