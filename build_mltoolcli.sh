#!/bin/bash

echo "Building mltoolcli"
dotnet build --nologo --verbosity minimal --configuration Release

echo "Copy pyscripts/ to build artifacts"
cp -ar pyscripts mltoolcli/bin/Release/net5.0

cd mltoolcli/bin/Release/net5.0
echo "Process complete. You can run the application with './mltoolcli' or 'sh run_mltoolcli.sh'"
