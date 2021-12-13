@echo off
title mltoolcli build

Rem mltoolcli build script for Windows

Rem creates artifacts folder if not exists
if not exist "%~dp0\artifacts\" mkdir %~dp0\artifacts

echo:
echo 1. Clean up artifacts folder
echo:
del /s /q "%~dp0\artifacts\*.*"

echo:
echo 2. Clean up build output folder
echo:
del /s /q "%~dp0\mltoolcli\bin\Release\net6.0\*.*"

echo:
echo 3. Build mltoolcli for Release
echo:
dotnet build --nologo --verbosity minimal --configuration Release

echo:
echo 4. Copy mltoolcli to artifacts
echo:
xcopy %~dp0\mltoolcli\bin\Release\net6.0 %~dp0\artifacts

echo:
echo 5. Copy pyscripts folder to artifacts
echo:
Rem creates pyscripts folder in build folder if not exists
if not exist "%~dp0\artifacts\pyscripts\" mkdir %~dp0\artifacts\pyscripts
Rem copies scripts to previously created folder
xcopy %~dp0\pyscripts %~dp0\artifacts\pyscripts

echo:
echo:
echo Build script completed. Application can be launched using Powershell or Command Prompt
echo:
pause