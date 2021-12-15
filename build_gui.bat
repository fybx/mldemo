@echo off
title mltoolgui build

Rem mltoolgui build script for Windows

Rem creates artifacts folder if not exists
if not exist "%~dp0\artifacts\" mkdir %~dp0\artifacts

echo:
echo 1. Clean up artifacts folder
echo:
del /s /q "%~dp0\artifacts\*.*"

echo:
echo 2. Clean up mltoolgui build output folder
echo:
del /s /q "%~dp0\mltoolgui\bin\Release\net6.0-windows\*.*"

echo:
echo 3. Clean up mltoolcli build output folder
echo:
del /s /q "%~dp0\mltoolcli\bin\Release\net6.0\*.*"

echo:
echo 4. Build mltoolcli for Release
echo:
dotnet build mltoolcli --nologo --verbosity minimal --configuration Release

echo:
echo 5. Build mltoolgui for Release
echo:
dotnet build mltoolgui --nologo --verbosity minimal --configuration Release

echo:
echo 6. Copy mltoolgui to artifacts
echo:
xcopy %~dp0\mltoolgui\bin\Release\net6.0-windows %~dp0\artifacts

echo:
echo 7. Copy mltoolcli to artifacts
echo:
xcopy %~dp0\mltoolcli\bin\Release\net6.0 %~dp0\artifacts

echo:
echo 8. Copy pyscripts folder to artifacts
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
