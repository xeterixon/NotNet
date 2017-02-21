#!/bin/bash
mono NuGet.exe pack ../NotNet.Core.Forms/NotNet.Core.Forms/NotNet.Core.Forms.csproj -properties  Configuration=Release
mono NuGet.exe pack ../NotNet.Core/NotNet.Core/NotNet.Core.csproj -properties  Configuration=Release

