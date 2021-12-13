Rem mltoolcli build script for Windows

@echo off

echo:
echo Building mltoolcli
echo:
dotnet build --nologo --verbosity minimal --configuration Release

echo:
echo Copy pyscripts folder to build artifacts
echo:
Rem creates pyscripts folder in build folder if not exists
if not exist "%~dp0\mltoolcli\bin\Release\net6.0\pyscripts\" mkdir %~dp0\mltoolcli\bin\Release\net6.0\pyscripts
Rem copies scripts to previously created folder
xcopy %~dp0\pyscripts %~dp0\mltoolcli\bin\Release\net6.0\pyscripts

echo:
echo:
echo Build script completed. Application can be launched using Powershell or Command Prompt
echo:
pause