#!/bin/bash

mkdir -p artifacts

echo "Clean-up artifacts"
cd artifacts
rm -rf *
cd ..

echo "Building mltoolcli"
dotnet build --nologo --verbosity minimal --configuration Release

echo "Copy build artifacts to artifacts folder"
cp -ar mltoolcli/bin/Release/net6.0/. artifacts

echo "Copy pyscripts folder to artifacts folder"
cp -ar pyscripts artifacts

echo "Process complete. You can run the application with './mltoolcli' or 'sh run_mltoolcli.sh'"
