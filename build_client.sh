#!/bin/bash

mkdir -p artifacts

echo "1. Clean up artifacts folder"
rm -rf ./artifacts/*

echo "2. Clean up build output folder"
rm -rf ./mltoolcli/bin/Release/net6.0/*

echo "3. Build mltoolcli for Release"
dotnet build --nologo --verbosity minimal --configuration Release

echo "4. Copy mltoolcli to artifacts"
cp -ar mltoolcli/bin/Release/net6.0/. artifacts

echo "5. Copy pyscripts folder to artifacts"
cp -ar pyscripts artifacts

echo "Build script completed."
